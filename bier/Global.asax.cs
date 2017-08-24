using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using log4net;
using log4net.Config;

namespace Bier
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            XmlConfigurator.Configure();
            HttpContext.Current.Application["DumbCache"]  = 
                new DumbCache(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType), 
                new HttpWebRequestFactory());
        }
    }
}
