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
using Data_Access.Concrete;
using Entities.Concrete;
using Entities.Dto;

namespace BlockChain
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Process process;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            process = new Process();
            process.StartInfo.FileName = "node.exe";
            var directoryInfo = Directory.GetParent(Server.MapPath("~"))?.Parent;
            if (directoryInfo != null)
            {
                var path = directoryInfo?.FullName + "/NodejsAPI/app.js";
                process.StartInfo.Arguments = path;
            }

            process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            process.Start();
            
        }


      
    }
}
