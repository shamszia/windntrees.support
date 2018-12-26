using System.Web.Mvc;
using DataAccess;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using DataAccess.Repositories;
using Abstraction.Providers;

namespace Application.Areas.Admin.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class AdvertisementPageController : CRUDController<AdvertisementPage>
    {
        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<AdvertisementPage> GetRepository()
        {
            RepositoryContent = new AdvertisementPageRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }
    }
}