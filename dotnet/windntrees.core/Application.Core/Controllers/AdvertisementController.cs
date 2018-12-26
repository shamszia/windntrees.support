using Abstraction.Core.Controllers;
using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
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
    [Authorize(Roles = "mngr_advertisements")]
    public class AdvertisementController : CRUDController<Advertisement>
    {
        // GET: Advertisement
        public IActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<Advertisement> GetRepository()
        {
            RepositoryContent = new AdvertisementRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
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
        public override JsonResult List([FromBody] SearchFilter searchQuery)
        {
            return base.List(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult Find([FromBody] SearchFilter searchQuery)
        {
            return base.Find(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult SelectList([FromBody] SearchFilter searchQuery)
        {
            return base.SelectList(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult Select([FromBody] SearchFilter searchQuery)
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
        public JsonResult GetLatestBy([FromBody] SearchFilter searchQuery)
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
                var result = ((ApplicationContext)DBContext).Advertisement.Where(l => l.News == true && l.Enabled == true).OrderByDescending(l => l.UpdateTime).FirstOrDefault();
                return GetObjectResult(result, null, true);
            }
            catch (Exception ex)
            {
                return GetObjectResultWithException(null, ex);
            }
        }
    }
}