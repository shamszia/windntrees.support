using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using DataAccess.Core;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_users")]
    public class AdvertisementLocationController : CRUDController<AdvertisementLocation>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<AdvertisementLocation> GetRepository()
        {
            RepositoryContent = new AdvertisementLocationRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }
    }
}