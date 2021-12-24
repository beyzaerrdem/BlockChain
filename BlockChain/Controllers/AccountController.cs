using BlockChain.Models;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Helpers;
using Data_Access.EntityFramework;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlockChain.Controllers
{
    public class AccountController : Controller
    {
        IUserCheckService _userCheckService = new UserCheckManager();
        IUserService _userService = new UserManager(new EfUserDal());
        IRegisteredUserService _registeredUserService = new RegisteredUserManager(new EfRegisteredUserDal());
        IRandomWordService _randomWordService = new RandomWordManager(new EfRandomWordDal());

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
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
                var hashedNumber = NodeJsAPIHelper.Hash(new {tc = registerModel.NationalityId });
                var isUserExist = _registeredUserService.IsUserExist(hashedNumber);

                if (!isUserExist)
                {
                    var randomWords = _randomWordService.GetRandomWords(5);
                    var key = NodeJsAPIHelper.CreateKey(randomWords);
                    var user = new User { UserName = registerModel.UserName, PublicKey = key.PublicKey, ProfilPhoto = "avatar.jpg" };
                    _userService.Add(user);
                    _registeredUserService.Add(new RegisteredUser {HashValue = hashedNumber });

                    ViewBag.PrivateId = key.PrivateKey;
                }
            }

            return View("~/Views/account/index.cshtml", registerModel);
        }

        [HttpPost]
        public ActionResult Login(string PrivateKey, string ReturnUrl)
        {
            var publicKey = NodeJsAPIHelper.PrivateKeyToPublicKey(PrivateKey);
            var user = _userService.GetUser(publicKey);

            var url = string.IsNullOrEmpty(ReturnUrl) ? "/" : ReturnUrl;

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(PrivateKey, false);
                Session["privateKey"] = PrivateKey;

                return Redirect(url);
            }

            return View("~/Views/account/index.cshtml");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/account");
        }
    }
}