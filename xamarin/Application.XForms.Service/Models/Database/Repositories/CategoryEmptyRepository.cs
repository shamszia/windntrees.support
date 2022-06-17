using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WindnTrees.CRUDS.Repository.Core;
using WindnTrees.ICRUDS.Standard;

namespace WindnTreesSEO.Models.Database.Repositories
{
    public class CategoryEmptyRepository : EntityEmptyRepository<Category>
    {
        public CategoryEmptyRepository(ApplicationContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, false)
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
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Title.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<Category> SortRecords(IQueryable<Category> query, SearchInput searchQuery = null)
        {
            IOrderedQueryable<Category> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descend == null ? false : ((bool)searchQuery.descend))
                {
                    orderInterface = query.OrderByDescending(l => l.Title);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.Title);
                }
            }
            return orderInterface;
        }

        protected override Category GetContentForCreate()
        {
            return new Category
            {
                Uid = Guid.NewGuid(),
                Title = string.Format("{0}{1}", "C", DateTime.Now.ToString("ddHHmmss")),
                Description = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }

        protected override string GetIdForRead()
        {
            var category = new ApplicationContext().Category.OrderByDescending(l => l.Description).FirstOrDefault();
            return category.Uid.ToString();
        }

        protected override Category GetContentForUpdate()
        {
            var category = new ApplicationContext().Category.OrderByDescending(l => l.Description).FirstOrDefault();
            category.Title = string.Format("{0}{1}", "C", DateTime.Now.ToString("ddHHmmss"));
            return category;
            //return new Category { Uid = color.Uid, Name = color.Name, Description = color.Description };
        }

        protected override Category GetContentForDelete()
        {
            var category = new ApplicationContext().Category.OrderByDescending(l => l.Description).FirstOrDefault();
            return category;
            //return new Category { Uid = color.Uid, Name = color.Name, Description = color.Description };
        }

        protected override SearchInput GetConditionsForListing()
        {
            return new SearchInput
            {
                keyword = ""
            };
        }

        //repository target (CRUDMethod)

        public Category CreateCRUD()
        {
            return base.Create();
        }

        public Category ReadCRUD()
        {
            return base.Read();
        }

        public Category UpdateCRUD()
        {
            return base.Update();
        }

        public Category DeleteCRUD()
        {
            return base.Delete();
        }

        public List<Category> ListCRUD()
        {
            return base.List();
        }

        public int ListCRUDTotal()
        {
            return base.ListTotal();
        }
    }
}
