using Microsoft.EntityFrameworkCore;
using WindnTrees.Abstraction.Core.Controllers;
using WindnTrees.CRUDS.Repository.Core;
using WindnTreesSEO.Models.Database;
using WindnTreesSEO.Models.Database.Repositories;

namespace WindnTreesSEO.Controllers
{
    public class RatingController : CRUDLController<Rating>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override EntityRepository<Rating> GetRepository()
        {
            return new RatingRepository((ApplicationContext)GetDBContext());
        }
    }
}