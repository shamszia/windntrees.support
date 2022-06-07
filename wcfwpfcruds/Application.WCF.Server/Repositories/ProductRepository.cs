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
    public class ProductRepository : ServiceRepository<Product>
    {
        public ProductRepository()
            : base(new ApplicationEntities())
        {

        }

        public ProductRepository(ApplicationEntities dbContext, string relatedObjects = "ProductFeatures", bool enableLazyLoading = false)
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

        public override Product Create(Product contentObject)
        {
            try
            {
                return base.Create(contentObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override Product Update(Product contentObject)
        {
            try
            {
                var exitingProduct = ((DbSet<Product>)entitySet).Include("ProductFeatures").Where(l => l.UID == contentObject.UID).SingleOrDefault();
                if (exitingProduct != null)
                {
                    exitingProduct.ProductFeatures.Clear();
                    context.SaveChanges();

                    foreach(var feature in contentObject.ProductFeatures)
                    {
                        feature.Product = null;
                        exitingProduct.ProductFeatures.Add(feature);
                    }

                    context.Entry(exitingProduct).CurrentValues.SetValues(contentObject);
                }

                if (context.SaveChanges() > 0)
                {
                    return PostUpdate(exitingProduct);
                }

                return exitingProduct;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public override List<Product> List(SearchInput queryObject)
        {
            try
            {
                return base.List(queryObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Invoke following method from service client using MethodSearch, BeginMethodSearch functions. 
        /// There is no need of additional or customized service contract to invoke following method.
        /// </summary>
        /// <param name="searchInput"></param>
        /// <returns></returns>
        public Product GetProductByID(SearchInput searchInput)
        {
            try
            {
                //Alternatively, user might want to search product from database context based on keyword and then return response.
                return new Product { UID = Guid.NewGuid(), Name = "Product 1", Description = "Description 1" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Invoke following method from service client using MethodSearch, BeginMethodSearch functions. 
        /// There is no need of additional or customized service contract to invoke following method.
        /// </summary>
        /// <param name="searchInput"></param>
        /// <returns></returns>
        public Product GetProductByName(SearchInput searchInput)
        {
            try
            {
                //Alternatively, user might want to search product from database context based on keyword and then return response.
                return new Product { UID = Guid.NewGuid(), Name = "Product 1", Description = "Description 1" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Note: Use ServiceClient "Method" functions to invoke other repository methods with same interface
        //IService (IServiceAsync) or IWCFService (IWCFServiceAsync)

        //public List<Product> SearchCustomList1(SearchInput searchInput)
        //{
        //    return null;
        //}

        //public List<Product> SearchCustomList2(SearchInput searchInput)
        //{
        //    return null;
        //}

        //public Product AddProductByMethod(Product product)
        //{
        //    return null;
        //}
    }
}
