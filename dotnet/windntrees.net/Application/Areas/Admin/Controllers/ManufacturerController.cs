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
    public class ManufacturerController : CRUDController<Manufacturer>
    {
        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Manufacturer> GetRepository()
        {
            RepositoryContent = new ManufacturerRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }
    }
}