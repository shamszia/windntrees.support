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
    [Authorize(Roles = "mngr_configurations")]
    public class ConfigurationsController : CRUDController<Configuration>
    {
        public IActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<Configuration> GetRepository()
        {
            RepositoryContent = new ConfigurationsRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
        }
    }
}
