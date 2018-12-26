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
    public class UnitController : CRUDController<Unit>
    {
        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Unit> GetRepository()
        {
            RepositoryContent = new UnitRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }
    }
}