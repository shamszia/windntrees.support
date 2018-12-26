using Abstraction.Core.Filters;
using Abstraction.Core.Repository;
using DataAccess.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Core.Repositories
{
    public class ConfigurationsRepository : EntityRepository<Configuration>
    {
        public ConfigurationsRepository(ApplicationContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override Configuration GenerateNewKey(Configuration contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Configuration> QueryRecords(IQueryable<Configuration> query, SearchFilter searchQuery = null)
        {
            Expression<Func<Configuration, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.KeyParam.Contains(searchQuery.keyword) || l.ValParam.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<Configuration> SortRecords(IQueryable<Configuration> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<Configuration> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.KeyParam);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.KeyParam);
                }
            }
            return orderInterface;
        }


        #region GetKeyValue()
        public string GetKeyValue(string key)
        {
            try
            {
                var content = ((ApplicationContext)context).Configuration.Where(l => l.KeyParam == key).SingleOrDefault();
                if (content != null)
                {
                    return content.ValParam;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        #endregion

        #region GetList()
        public GenericListString[] GetList()
        {
            try
            {
                List<GenericListString> contents = ((ApplicationContext)context).Configuration.OrderBy(l => l.KeyParam).ToList()
                    .Select(param =>
                    {
                        return new GenericListString
                        {
                            ItemText = param.KeyParam,
                            ItemValue = param.ValParam
                        };
                    }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        #endregion
    }
}
