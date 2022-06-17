using Microsoft.EntityFrameworkCore;
using WindnTrees.Abstraction.Core.Controllers;
using WindnTrees.CRUDS.Repository.Core;
using WindnTreesSEO.Models.Database.Repositories;
using WindnTreesSEO.Models.Database;

namespace WindnTreesSEO.Controllers
{
    public class SkillLevelController : CRUDLController<SkillLevel>
    {
        protected override DbContext GetDBContext()
        {
            return new ApplicationContext();
        }

        protected override EntityRepository<SkillLevel> GetRepository()
        {
            return new SkillLevelRepository((ApplicationContext)GetDBContext());
        }
    }
}