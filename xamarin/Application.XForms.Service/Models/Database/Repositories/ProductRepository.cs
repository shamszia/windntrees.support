using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WindnTrees.CRUDS.Repository.Core;
using WindnTrees.ICRUDS.Standard;

namespace WindnTreesSEO.Models.Database.Repositories
{
    public class ProductRepository : EntityRepository<Product>
    {
        public ProductRepository(ApplicationContext dbContext, string relatedObjects = "")
            : base(dbContext, relatedObjects)
        { }

        protected override Product GenerateNewKey(Product contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Product> QueryRecords(IQueryable<Product> query, SearchInput searchQuery = null)
        {
            Expression<Func<Product, bool>> condition = null;

            if (searchQuery.keys != null)
            {
                var categoryKey = ((List<SearchField>)searchQuery.keys).Where(l => l.field == "category").SingleOrDefault();
                if (categoryKey != null)
                {
                    if (!string.IsNullOrEmpty(categoryKey.value))
                    {
                        query = query.Where(l => l.Category.Equals(categoryKey.value));
                    }
                }
            }

            if (!string.IsNullOrEmpty(searchQuery.keyword))
            {
                condition = l => (l.Name.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword));
                query = query.Where(condition);
            }

            return query;
        }

        protected override IOrderedQueryable<Product> SortRecords(IQueryable<Product> query, SearchInput searchQuery = null)
        {
            IOrderedQueryable<Product> orderInterface = null;
            if (searchQuery.descend ==  null ? false : ((bool)searchQuery.descend))
            {
                orderInterface = query.OrderByDescending(l => l.Name);
            }
            else
            {
                orderInterface = query.OrderBy(l => l.Name);
            }

            return orderInterface;
        }
    }
}
