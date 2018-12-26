using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class RoleController : CRUDController<Role>
    {
        public ActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Role> GetRepository()
        {
            RepositoryContent = new RolesRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }
    }
}