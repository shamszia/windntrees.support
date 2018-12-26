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
    public class CategoryController : CRUDController<Category>
    {
        protected override DbContext GetDBContext()
        {
            return new DatabaseContext();
        }

        protected override ContentRepository<Category> GetRepository()
        {
            RepositoryContent = new CategoryRepository((DatabaseContext)GetDBContext());
            return RepositoryContent;
        }
    }
}