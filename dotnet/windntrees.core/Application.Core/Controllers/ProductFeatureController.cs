using Abstraction.Core.Controllers;
using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using DataAccess.Core;
using DataAccess.Core.Models;
using DataAccess.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class ProductFeatureController : CRUDController<ProductFeature>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override ContentRepository<ProductFeature> GetRepository()
        {
            RepositoryContent = new ProductFeatureRepository((ApplicationContext)GetDBContext());
            return RepositoryContent;
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
        public override JsonResult SelectList(SearchFilter searchQuery)
        {
            return base.SelectList(searchQuery);
        }

        [AllowAnonymous]
        public override JsonResult Select(SearchFilter searchQuery)
        {
            return base.Select(searchQuery);
        }
    }
}