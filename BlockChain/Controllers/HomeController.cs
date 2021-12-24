using System;
using System.Collections.Generic;
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
            (new BlockManager(new EfBlockDal()), new TransactionManager(new EfTransactionDal()));

        public ActionResult Index()
        {
            var posts = _chainService.GetAllTransactions();
            return View(posts);
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