using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_configurations")]
    public class ConfigurationsController : CRUDController<Configuration>
    {
        public ActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Configuration> GetRepository()
        {
            RepositoryContent = new ConfigurationsRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }
    }
}
