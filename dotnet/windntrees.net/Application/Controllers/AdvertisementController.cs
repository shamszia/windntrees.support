using DataAccess;
using DataAccess.Repositories;
using Abstraction.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Controllers
{
    [Authorize(Roles = "mngr_advertisements")]
    public class AdvertisementController : CRUDController<Advertisement>
    {
        // GET: Advertisement
        public ActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Advertisement> GetRepository()
        {
            RepositoryContent = new AdvertisementRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
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
        public override JsonResult List(SearchFilter searchQuery)
        {
            return base.List(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult Find(SearchFilter searchQuery)
        {
            return base.Find(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult SelectList(SearchFilter searchQuery)
        {
            return base.SelectList(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult Select(SearchFilter searchQuery)
        {
            return base.Select(searchQuery);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetLatest(string count = "5")
        {
            try
            {   
                var results = ((EntityRepository<Advertisement>)RepositoryContent).GetRandomList(new SearchFilter { total = int.Parse(count) });
                return GetListResult(results.ToList(), null, true);
            }
            catch (Exception ex)
            {
                return GetListResultWithException(null, ex);
            }
        }

        [AllowAnonymous]
        public JsonResult GetLatestBy(SearchFilter searchQuery)
        {
            try
            {
                var results = ((EntityRepository<Advertisement>)RepositoryContent).GetRandomList(searchQuery);
                return GetListResult(results.ToList(), null, true);
            }
            catch (Exception ex)
            {
                return GetListResultWithException(null, ex);
            }
        }

        [AllowAnonymous]
        public JsonResult GetLatestNews(string count = "5")
        {
            try
            {
                List<ListObject> keywords = new List<ListObject>();
                keywords.Add(new ListObject { Field = "News", Value = "True" });

                var results = ((EntityRepository<Advertisement>)RepositoryContent).GetRandomList(new SearchFilter { keywords = keywords, total = int.Parse(count) });
                return GetListResult(results.ToList(), null, true);
            }
            catch (Exception ex)
            {
                return GetListResultWithException(null, ex);
            }
        }

        [AllowAnonymous]
        public JsonResult GetLatestNewsSingle()
        {
            try
            {
                var result = ((DatabaseContext)DBContext).Advertisements.Where(l => l.News == true && l.Enabled == true).OrderByDescending(l => l.UpdateTime).FirstOrDefault();
                return GetObjectResult(result, null, true);
            }
            catch (Exception ex)
            {
                return GetObjectResultWithException(null, ex);
            }
        }
    }
}