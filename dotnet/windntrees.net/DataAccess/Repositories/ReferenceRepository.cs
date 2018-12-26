using System;
using System.Collections.Generic;
using System.Linq;
using Abstraction.Results;
using Abstraction.Filters;
using System.Linq.Expressions;
using Abstraction.Repository;

namespace DataAccess.Repositories
{
    public class ReferenceRepository : EntityRepository<Reference>
    {
        public ReferenceRepository(DatabaseContext dbContext, string relatedObjects = "", bool enableLazyLoading = false) 
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override Reference GenerateNewKey(Reference contentObject)
        {
            contentObject.UID = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Reference> QueryRecords(IQueryable<Reference> query, SearchFilter searchQuery = null)
        {
            Expression<Func<Reference, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.key))
                {
                    Nullable<Guid> key = null;
                    try
                    {
                        key = Guid.Parse(searchQuery.key);
                    }
                    catch { }

                    if (key != null)
                    {
                        condition = l => (l.ReferenceID == key);
                        query = query.Where(condition);
                    }
                }

                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Name.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<Reference> SortRecords(IQueryable<Reference> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<Reference> orderInterface = null;
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

        protected override Reference PostCreate(Reference contentObject)
        {
            contentObject.ContentBytes = null;
            return contentObject;
        }

        protected override Reference PostRead(Reference contentObject)
        {
            contentObject.ContentBytes = null;
            return contentObject;
        }

        protected override List<Reference> PostRead(List<Reference> list)
        {
            foreach(Reference refer in list)
            {
                refer.ContentBytes = null;
            }
            return list;
        }

        protected override PagedRecords<Reference> PostRead(PagedRecords<Reference> page)
        {
            foreach(Reference refer in page.RecordsList)
            {
                refer.ContentBytes = null;
            }
            return page;
        }

        protected override Reference PostUpdate(Reference contentObject)
        {
            contentObject.ContentBytes = null;
            return contentObject;
        }

        protected override List<Reference> PostSelect(List<Reference> list)
        {
            foreach(Reference refer in list)
            {
                refer.ContentBytes = null;
            }
            return list;
        }

        protected override PagedRecords<Reference> PostSelect(PagedRecords<Reference> page)
        {
            foreach(Reference refer in page.RecordsList)
            {
                refer.ContentBytes = null;
            }
            return page;
        }

        protected override Reference PostDelete(Reference contentObject)
        {
            contentObject.ContentBytes = null;
            return contentObject;
        }
    }
}
