using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using DataAccess.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Core.Repositories
{
    public class UnitRepository : EntityRepository<Unit>
    {
        public UnitRepository(ApplicationContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override Unit GenerateNewKey(Unit contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Unit> QueryRecords(IQueryable<Unit> query, SearchFilter searchQuery = null)
        {
            Expression<Func<Unit, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Name.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<Unit> SortRecords(IQueryable<Unit> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<Unit> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.Name);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.Name);
                }
            }
            return orderInterface;
        }

        #region GetList()
        public GenericListString[] GetList()
        {
            try
            {
                List<GenericListString> contents = ((ApplicationContext)context).Unit.OrderBy(l => l.Name).ToList()
                    .Select(param =>
                    {
                        return new GenericListString
                        {
                            ItemText = param.Name,
                            ItemValue = param.Uid.ToString()
                        };
                    }).ToList();

                return contents.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
