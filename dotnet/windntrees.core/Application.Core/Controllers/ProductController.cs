using Abstraction.Core.Controllers;
using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using DataAccess.Core;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Core.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class ProductController : CRUDController<Product>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<Product> GetRepository()
        {
            RepositoryContent = new ProductRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            byte[] companyTitleBytes = null;
            string companyTitle = null;

            try
            {
                HttpContext.Session.TryGetValue("CompanyTitle", out companyTitleBytes);
                companyTitle = System.Text.UTF8Encoding.UTF8.GetString(companyTitleBytes);
            }
            catch { }

            ViewBag.CurrencySymbol = "Rs. ";

            byte[] currencySymbolBytes = null;
            string currencySymbol = null;

            try
            {
                HttpContext.Session.TryGetValue("CurrencySymbol", out currencySymbolBytes);
                currencySymbol = System.Text.UTF8Encoding.UTF8.GetString(currencySymbolBytes);
            }
            catch { }
            
            ViewBag.CurrencySymbol = currencySymbol != null ? currencySymbol : ViewBag.CurrencySymbol;

            return View();
        }

        [AllowAnonymous]
        public ActionResult Information(string id)
        {
            if (id != null)
            {
                ViewData.Add(new KeyValuePair<string, object>("ProductID", id));
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Advertisements(string id)
        {
            if (id != null)
            {
                ViewData.Add(new KeyValuePair<string, object>("ProductID", id));
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult References(string id)
        {

            if (id != null)
            {
                ViewData.Add(new KeyValuePair<string, object>("ProductID", id));
            }

            return View();
        }

        [AllowAnonymous]
        public override JsonResult Get(string id)
        {
            return base.Get(id);
        }

        [AllowAnonymous]
        public override JsonResult Post([FromBody] SearchFilter searchQuery)
        {
            return base.Post(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult Find([FromBody] SearchFilter searchQuery)
        {
            return base.Find(searchQuery);
        }

        [AllowAnonymous]
        public JsonResult GetRandom()
        {
            try
            {
                var results = ((EntityRepository<Product>)RepositoryContent).GetRandomList(new SearchFilter { total = 18 });
                return GetListResult(results.ToList(), null, true);
            }
            catch (Exception ex)
            {
                return GetListResultWithException(null, ex);
            }
        }
    }
}