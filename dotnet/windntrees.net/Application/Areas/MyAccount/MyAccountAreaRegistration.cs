using System.Web.Mvc;

namespace Application.Areas.MyAccount
{
    public class MyAccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "myaccount";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "myaccount_default",
                "myaccount/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Application.Areas.MyAccount.Controllers" }
            );
        }
    }
}
