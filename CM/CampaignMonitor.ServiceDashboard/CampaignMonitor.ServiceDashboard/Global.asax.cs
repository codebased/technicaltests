using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CampaignMonitor.ServiceDashboard
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Add content negotiation here...
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.
                MediaTypeMappings.Add(new QueryStringMapping("format", "json", "application/json"));

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.
                MediaTypeMappings.Add(new QueryStringMapping("format", "xml", "application/xml"));

        }
    }
}