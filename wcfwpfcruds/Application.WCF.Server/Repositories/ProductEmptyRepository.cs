using System;
using System.Linq;
using WindnTrees.ICRUDS;
using System.Linq.Expressions;
using WindnTrees.CRUDS.Repository;
using System.Collections.Generic;
using Application.Models.Standard.DataAccess;
using Application.WCF.Server.DataAccess;
using System.Data.Entity;

namespace Application.WCF.Server.Repositories
{
    public class ProductEmptyRepository : ServiceEmptyRepository<Product>
    {
        public ProductEmptyRepository()
            : base(new ApplicationEntities())
        {

        }

        public ProductEmptyRepository(ApplicationEntities dbContext, string relatedObjects = "ProductFeatures", bool enableLazyLoading = false)
            : base(dbContext, relatedObjects, enableLazyLoading)
        {
            this.enableAsNoTracking = false;
        }

        protected override Product GenerateNewKey(Product contentObject)
        {
            contentObject.UID = Guid.NewGuid();


            if (contentObject.ProductFeatures != null)
            {
                foreach (var feature in contentObject.ProductFeatures)
                {
                    feature.ProductID = contentObject.UID;
                }
            }

            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Product> QueryRecords(IQueryable<Product> query, SearchInput searchQuery = null)
        {
            Expression<Func<Product, bool>> condition = null;
            if (!string.IsNullOrEmpty(searchQuery.key))
            {
                condition = l => (l.Manufacturer == searchQuery.key);
                query = query.Where(condition);
            }

            if (!string.IsNullOrEmpty(searchQuery.keyword))
            {
                condition = l => (l.Name.Contains(searchQuery.keyword) || l.Description.Contains(searchQuery.keyword) || l.Color.Contains(searchQuery.keyword));
                query = query.Where(condition);
            }
            return query;
        }

        protected override IOrderedQueryable<Product> SortRecords(IQueryable<Product> query, SearchInput searchQuery = null)
        {
            IOrderedQueryable<Product> orderInterface = null;

            orderInterface = query.OrderBy(l => l.Name);
            return orderInterface;
        }
        
        /// <summary>
        /// Creates new product.
        /// </summary>
        /// <returns></returns>
        protected override Product GetContentForCreate()
        {
            return new Product { UID = Guid.Empty, Name = string.Format("{0} {1}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), "Product"), Description = "" };
        }

        /// <summary>
        /// Reads last product.
        /// </summary>
        /// <returns></returns>
        protected override string GetIdForRead()
        {
            var product = new ApplicationEntities().Products.OrderByDescending(l => l.Name).FirstOrDefault();
            if (product != null)
            {
                return product.UID.ToString();
            }

            throw new Exception("No product found.");
        }

        /// <summary>
        /// Updates last product.
        /// </summary>
        /// <returns></returns>
        protected override Product GetContentForUpdate()
        {
            var product = new ApplicationEntities().Products.OrderByDescending(l => l.Name).FirstOrDefault();
            if (product != null)
            {
                product.Name = string.Format("{0} {1}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), "Product");
                return new Product { UID = product.UID, Name = product.Name, Description = product.Description };
            }

            throw new Exception("No product found.");
        }

        /// <summary>
        /// Deletes last product.
        /// </summary>
        /// <returns></returns>
        protected override Product GetContentForDelete()
        {
            var product = new ApplicationEntities().Products.OrderByDescending(l => l.Name).FirstOrDefault();
            if (product != null)
            {
                return new Product { UID = product.UID, Name = product.Name, Description = product.Description };
            }

            throw new Exception("No product found.");
        }

        /// <summary>
        /// List all products.
        /// </summary>
        /// <returns></returns>
        protected override SearchInput GetConditionsForListing()
        {
            return new SearchInput { keyword = "" };
        }
    }
}
