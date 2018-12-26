using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using DataAccess.Core;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LanguageController : BasicController
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

        // GET: Language
        public IActionResult Index(string returnUrl = "/admin/home/index")
        {
            string locale = "en";
            HttpContext.Session.Set("locale", System.Text.UTF8Encoding.UTF8.GetBytes(locale));
            HttpContext.Session.Set("bodyDirection", System.Text.UTF8Encoding.UTF8.GetBytes(GetLocaleDirection(locale)));

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(locale)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
            );

            return LocalRedirect(returnUrl);
        }

        // GET: Language
        public ActionResult Urdu(string returnUrl = "/admin/home/index")
        {
            string locale = "ur";
            HttpContext.Session.Set("locale", System.Text.UTF8Encoding.UTF8.GetBytes(locale));
            HttpContext.Session.Set("bodyDirection", System.Text.UTF8Encoding.UTF8.GetBytes(GetLocaleDirection(locale)));

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(locale)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddMonths(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}