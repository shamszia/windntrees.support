using System.Web.Mvc;
using Abstraction.Controllers;

namespace Application.Controllers
{
    public class HomeController : BasicController
    {
        public HomeController()
        {
            //this.GetType().Assembly.HostContext.GetType().GetNestedType
        }

        public ActionResult Index()
        {
            ViewBag.CompanyTitle = System.Configuration.ConfigurationManager.AppSettings["CompanyTitle"];
            ViewBag.CurrencySymbol = "Rs. ";
            ViewBag.CurrencySymbol = System.Configuration.ConfigurationManager.AppSettings["CurrencySymbol"] != null ? System.Configuration.ConfigurationManager.AppSettings["CurrencySymbol"] : ViewBag.CurrencySymbol;
            ViewBag.EQCurrencySymbol = "= " + ViewBag.CurrencySymbol;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.CompanyTitle = System.Configuration.ConfigurationManager.AppSettings["CompanyTitle"];
            ViewBag.CurrencySymbol = "Rs. ";
            ViewBag.CurrencySymbol = System.Configuration.ConfigurationManager.AppSettings["CurrencySymbol"] != null ? System.Configuration.ConfigurationManager.AppSettings["CurrencySymbol"] : ViewBag.CurrencySymbol;
            ViewBag.EQCurrencySymbol = "= " + ViewBag.CurrencySymbol;

            return View();
        }
    }
}
