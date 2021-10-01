using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebApiServices.TimerClass;

namespace WebApiServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FillRegDumpBlotter.Start();
            FillFwdDumpBlotter.Start();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_End() {
            FillRegDumpBlotter.Stop();
            FillFwdDumpBlotter.Stop();
        }
     
    }
}
