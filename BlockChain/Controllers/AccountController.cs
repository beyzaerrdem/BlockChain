using BlockChain.Models;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Helpers;
using Data_Access.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using System.Web.Mvc;
using System.Web.Security;

namespace BlockChain.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserCheckService _userCheckService = new UserCheckManager();
        private readonly IUserService _userService = new UserManager(new EfUserDal());
        private readonly IRegisteredUserService _registeredUserService = new RegisteredUserManager(new EfRegisteredUserDal());
        private readonly IRandomWordService _randomWordService = new RandomWordManager(new EfRandomWordDal());

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (_userService.CheckUserName(registerModel.UserName))
                return Json(new { status = false, errorMessage = "This username is already taken!" });

            var result = _userCheckService.CheckIfRealPerson(
                new UserValidationDto
                {
                    BirthYear = registerModel.BirthYear,
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    NationalatyId = registerModel.NationalityId
                });

            if (result)
            {
                var hashedNumber = NodeJsAPIHelper.Hash(new { tc = registerModel.NationalityId });
                var isUserExist = _registeredUserService.IsUserExist(hashedNumber);

                if (!isUserExist)
                {
                    var randomWords = _randomWordService.GetRandomWords(5);
                    var key = NodeJsAPIHelper.CreateKey(randomWords);
                    var user = new User { UserName = registerModel.UserName, PublicKey = key.PublicKey, ProfilPhoto = "avatar.jpg" };
                    _userService.Add(user);
                    _registeredUserService.Add(new RegisteredUser { HashValue = hashedNumber });

                    ViewBag.PrivateId = key.PrivateKey;
                    return Json(new { status = false, data = new { privateKey = key.PrivateKey, recoveryWords = randomWords } });
                } else
                {
                    return Json(new { status = false, errorMessage = "This user is already exist!" });
                }

            } else
            {
                return Json(new { status = false, errorMessage = "The user is not a Turkish citizen!" });
            }

        }

        [HttpPost]
        public ActionResult Login(string PrivateKey, string ReturnUrl)
        {
            var publicKey = NodeJsAPIHelper.PrivateKeyToPublicKey(PrivateKey);
            var user = _userService.GetUser(publicKey);

            var url = string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl;

            if (user == null) return View("~/Views/account/index.cshtml");
            FormsAuthentication.SetAuthCookie(PrivateKey, false);
            Session["privateKey"] = PrivateKey;

            return Redirect(url);

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/account");
        }
    }
}