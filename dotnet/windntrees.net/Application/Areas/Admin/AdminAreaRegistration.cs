using System.Web.Mvc;

namespace Application.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { controller = "home", action = "index", id = UrlParameter.Optional },
                namespaces: new string[] { "Application.Areas.Admin.Controllers" }
            );
        }
    }
}
