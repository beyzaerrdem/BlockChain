using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Helpers;
using Data_Access.EntityFramework;
using Entities.Concrete;
using Newtonsoft.Json;
using PagedList;

namespace BlockChain.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IChainService _chainService = new ChainManager
            (new BlockManager(new EfBlockDal()), new TransactionManager(new EfTransactionDal()),new EfChainDal());

        private INotificationService _notificationService = new NotificationManager(new EfNotificationDal());

        public ActionResult Index()
        {          
            var posts = _chainService.GetAllPostDtos().OrderByDescending(t=>t.Timestamp).ToList();
            var notifications = _notificationService.GetAllNotificationDtos();
            ViewBag.notifications = notifications;
            return View(posts);
        }

        [HttpPost]
        public ActionResult AddPost(string Post)
        {
            var privateKey = Session["privateKey"].ToString();
            NodeJsAPIHelper.CreatePost(privateKey, Post);
            return Redirect("/");
        }

        [AllowAnonymous]
        public ActionResult GetBlocks()
        {
            var model =_chainService.GetAllBlocks();
            return View(model);
        }
    }
}