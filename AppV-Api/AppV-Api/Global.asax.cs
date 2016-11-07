using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace AppV_Api
{

    
    public class WebApiApplication : System.Web.HttpApplication
    {
        private SignalR _signalR;

        public WebApiApplication()
        {
            _signalR = new SignalR();
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            _signalR.Start();
        }
    }
}
