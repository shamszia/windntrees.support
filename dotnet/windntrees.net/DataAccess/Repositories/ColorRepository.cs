﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Abstraction.Filters;
using Abstraction.Repository;

namespace DataAccess.Repositories
{
    public class ColorRepository : EntityRepository<Color>
    {
        public ColorRepository(DatabaseContext dbContext, string relatedObjects = "", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override Color GenerateNewKey(Color contentObject)
        {
            contentObject.UID = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Color> QueryRecords(IQueryable<Color> query, SearchFilter searchQuery = null)
        {
            Expression<Func<Color, bool>> condition = null;
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

        protected override IOrderedQueryable<Color> SortRecords(IQueryable<Color> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<Color> orderInterface = null;
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
                List<GenericListString> contents = ((DatabaseContext)context).Colors.OrderBy(l => l.Name).ToList()
                    .Select(param =>
                    {
                        return new GenericListString
                        {
                            ItemText = param.Name,
                            ItemValue = param.UID.ToString()
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