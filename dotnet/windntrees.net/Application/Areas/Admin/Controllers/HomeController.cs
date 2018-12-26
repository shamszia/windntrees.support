using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : CRUDController<LoginHistory>
    {
        public ActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<LoginHistory> GetRepository()
        {
            RepositoryContent = new LoginHistoryRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }
    }
}
