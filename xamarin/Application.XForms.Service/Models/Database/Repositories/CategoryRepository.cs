using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WindnTrees.CRUDS.Repository.Core;
using WindnTrees.ICRUDS.Standard;

namespace WindnTreesSEO.Models.Database.Repositories
{
    public class CategoryRepository : EntityRepository<Category>
    {
        public CategoryRepository(ApplicationContext dbContext, string relatedObjects = "")
            : base(dbContext, relatedObjects)
        { }

        protected override Category GenerateNewKey(Category contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Category> QueryRecords(IQueryable<Category> query, SearchInput searchQuery = null)
        {
            Expression<Func<Category, bool>> condition = null;
            if (!string.IsNullOrEmpty(searchQuery.keyword))
            {
                condition = l => (l.Title.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword));
                query = query.Where(condition);
            }

            return query;
        }

        protected override IOrderedQueryable<Category> SortRecords(IQueryable<Category> query, SearchInput searchQuery = null)
        {
            IOrderedQueryable<Category> orderInterface = null;
            if (searchQuery.descend ==  null ? false : ((bool)searchQuery.descend))
            {
                orderInterface = query.OrderByDescending(l => l.Title);
            }
            else
            {
                orderInterface = query.OrderBy(l => l.Title);
            }
            return orderInterface;
        }

        //CRUD Repository

        public Category CreateCRUD(Category contentObject)
        {
            return base.Create(contentObject);
        }

        public Category ReadCRUD(object id)
        {
            return base.Read(id);
        }

        public Category UpdateCRUD(Category contentObject)
        {
            return base.Update(contentObject);
        }

        public Category DeleteCRUD(Category contentObject)
        {
            return base.Delete(contentObject);
        }

        public List<Category> ListCRUD(SearchInput queryObject)
        {
            return base.List(queryObject);
        }

        public int ListCRUDTotal(SearchInput queryObject)
        {
            return base.ListTotal(queryObject);
        }

        public int EmptyCRUD()
        {
            return 0;
        }
    }
}
