using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BlockChain
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            var path=Directory.GetParent(Server.MapPath("~")).Parent.FullName+ "/BlockChainNodejsApi";
            process.StartInfo.Arguments = "/k cd "+path+"&&npm i&&node app.js";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.Start();
        }
    }
}
