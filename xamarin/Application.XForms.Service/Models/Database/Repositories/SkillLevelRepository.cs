using System;
using System.Linq;
using System.Linq.Expressions;
using WindnTrees.CRUDS.Repository.Core;
using WindnTrees.ICRUDS.Standard;

namespace WindnTreesSEO.Models.Database.Repositories
{
    public class SkillLevelRepository : EntityRepository<SkillLevel>
    {
        public SkillLevelRepository(ApplicationContext dbContext, string relatedObjects = "")
            : base(dbContext, relatedObjects)
        { }

        protected override SkillLevel GenerateNewKey(SkillLevel contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<SkillLevel> QueryRecords(IQueryable<SkillLevel> query, SearchInput searchQuery = null)
        {
            Expression<Func<SkillLevel, bool>> condition = null;
            if (!string.IsNullOrEmpty(searchQuery.keyword))
            {
                condition = l => (l.Title.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword));
                query = query.Where(condition);
            }

            return query;
        }

        protected override IOrderedQueryable<SkillLevel> SortRecords(IQueryable<SkillLevel> query, SearchInput searchQuery = null)
        {
            IOrderedQueryable<SkillLevel> orderInterface = null;
            if (searchQuery.descend == null ? false : ((bool)searchQuery.descend))
            {
                orderInterface = query.OrderByDescending(l => l.Title);
            }
            else
            {
                orderInterface = query.OrderBy(l => l.Title);
            }
            return orderInterface;
        }
    }
}