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
using System.Linq;

namespace Application.Core.Controllers
{
    [Authorize(Roles = ("mngr_advertisements"))]
    public class NewsController : CRUDController<Advertisement>
    {
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
        public IActionResult Index()
        {
            return View();
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
        public JsonResult GetLatest(string count = "5")
        {
            try
            {
                var results = ((EntityRepository<Advertisement>)RepositoryContent).GetRandomList(new SearchFilter { total = 18 });
                return GetListResult(results.ToList(), null, true);
            }
            catch (Exception ex)
            {
                return GetListResultWithException(null, ex);
            }
        }
    }
}
