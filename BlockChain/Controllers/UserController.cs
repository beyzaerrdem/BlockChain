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

namespace BlockChain.Controllers
{
    public class UserController : Controller
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
                    NationalatyId = registerModel.NationalatyId
                });

            if (result)
            {
                _randomWordService.GetAll();
                NodeJsAPIHelper.Hash();
            }

            if (result)
            {
                var user = new User { UserName = registerModel.UserName, PublicKey = "1"};

            }

         
            return View(registerModel);
        }

        [HttpPost]
        public ActionResult Login()
        {
            return View();
        }

    }
}