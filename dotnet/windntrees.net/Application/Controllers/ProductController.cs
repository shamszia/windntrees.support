using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Filters;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class ProductController : CRUDController<Product>
    {
        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Product> GetRepository()
        {
            RepositoryContent = new ProductRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.CompanyTitle = System.Configuration.ConfigurationManager.AppSettings["CompanyTitle"];
            ViewBag.CurrencySymbol = "Rs. ";
            ViewBag.CurrencySymbol = System.Configuration.ConfigurationManager.AppSettings["CurrencySymbol"] != null ? System.Configuration.ConfigurationManager.AppSettings["CurrencySymbol"] : ViewBag.CurrencySymbol;

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
        public override JsonResult Post(SearchFilter searchQuery)
        {
            return base.Post(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult Find(SearchFilter searchQuery)
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