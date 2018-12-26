using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using Abstraction.Filters;
using Abstraction.Controllers;
using System.Data.Entity;
using Abstraction.Repository;
using Abstraction.Providers;

namespace Application.Controllers
{
    [Authorize(Roles = "mngr_users")]
    public class ReferenceController : CRUDController<Reference>
    {
        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Reference> GetRepository()
        {
            RepositoryContent = new ReferenceRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }

        [AllowAnonymous]
        public override JsonResult Get(string id)
        {
            return base.Get(id);
        }

        [AllowAnonymous]
        public override JsonResult Post(SearchFilter searchQuery)
        {
            return base.Post(searchQuery);
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