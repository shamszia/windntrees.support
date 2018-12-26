using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Areas.Admin.Controllers
{
    public class LanguageController : Controller
    {
        private string[] rtlLocales = new string[] { "ur" };

        private string GetLocaleDirection(string locale)
        {
            if (rtlLocales.Contains(locale))
            {
                return "rtl";
            }

            return "";
        }

        // GET: Admin/Language
        public ActionResult Index()
        {
            Session["locale"] = "en";
            Session["bodyDirection"] = GetLocaleDirection("en");

            if (Request.UrlReferrer != null)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }

            return RedirectToAction("index", "home");
        }

        // GET: Language
        public ActionResult Urdu()
        {
            Session["locale"] = "ur";
            Session["bodyDirection"] = GetLocaleDirection("ur");

            if (Request.UrlReferrer != null)
            {
                return Redirect(Request.UrlReferrer.ToString());
            }

            return RedirectToAction("index", "home");
        }
    }
}