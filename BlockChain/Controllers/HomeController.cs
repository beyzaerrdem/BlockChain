using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Business.Utilities.Helpers;
using Entities.Concrete;
using Newtonsoft.Json;

namespace BlockChain.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(string Post)
        {
            var privateKey = Session["privateKey"].ToString();
            NodeJsAPIHelper.CreatePost(privateKey, Post);
            return Redirect("/");
        }
    }
}