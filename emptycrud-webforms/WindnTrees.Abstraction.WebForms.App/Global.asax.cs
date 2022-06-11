using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WindnTrees.Abstraction.WebForms.Routing;

namespace WindnTrees.Abstraction.WebForms.App
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RouteTable.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { action = "Get", id = System.Web.Http.RouteParameter.Optional });

            GlobalConfiguration.Configuration.MapHttpAttributeRoutes(new DefaultRouteProviderSetting());

            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}