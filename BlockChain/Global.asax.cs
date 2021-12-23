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
using Business.Adapters;
using Business.Utilities.Helpers;
using Entities.Concrete;
using Entities.Dto;

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
            process.StartInfo.FileName = "node.exe";
            var directoryInfo = Directory.GetParent(Server.MapPath("~"))?.Parent;
            if (directoryInfo != null)
            {
                var path = directoryInfo?.FullName + "/NodejsAPI/app.js";
                process.StartInfo.Arguments = path;
            }

            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.Start();
            var t = NodeJsAPIHelper.PrivateKeyToPublicKey("2b59c50d6c3b14de33f3a091e05666e790dc2c0da9b49f25baecdaa1dd16311b");
        }
    }
}
