using Abstraction.Core.Controllers;
using Abstraction.Core.Repository;
using Application.Core.Data;
using Application.Core.Models;
using Application.Core.Models.Configuration;
using Application.Core.Services;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Application.Core.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "mngr_users")]
    public class RoleController : CRUDController<IdentityRole>
    {   
        private IOptions<ApplicationSettings> _settingsOptions;
        private readonly ILogger<RoleController> _logger;

        public RoleController(ILogger<RoleController> logger,
            IOptions<ApplicationSettings> settings)
        {
            _logger = logger;
            _settingsOptions = settings;
        }

        public ActionResult Index()
        {
            return View();
        }

        protected override DbContext GetDBContext()
        {   
            return new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
        }

        protected override ContentRepository<IdentityRole> GetRepository()
        {
            RepositoryContent = new IdentityRoleRepository((ApplicationDbContext)GetDBContext());
            return RepositoryContent;
        }
    }
}