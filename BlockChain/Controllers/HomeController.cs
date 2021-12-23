using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Entities.Concrete;
using Newtonsoft.Json;

namespace BlockChain.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public Task<ActionResult> Post()
        {
            //var t = new Transaction();

            using (var client = new HttpClient())
            {
                var uri = new Uri("http://localhost:8081/api/post/addpost");

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(new{postOwner= "2421ebb2aa51fad4a51276a37bf0824f50cd4864c733567b968926f2f617d652",post="merhaba" }), Encoding.UTF8, "application/json");
                var response = client.SendAsync(requestMessage).GetAwaiter().GetResult();
                var t=response.Content.ReadAsAsync<Transaction>().Result;
                return Task.FromResult<ActionResult>(Json(t,JsonRequestBehavior.AllowGet));
            }

            
        }
    }
}