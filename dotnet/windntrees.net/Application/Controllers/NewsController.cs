using System;
using System.Linq;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Controllers;
using Abstraction.Filters;
using System.Data.Entity;
using Abstraction.Repository;

namespace Application.Controllers
{
    [Authorize(Roles = ("mngr_advertisements"))]
    public class NewsController : CRUDController<Advertisement>
    {
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
        public ActionResult Index()
        {
            return View();
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
