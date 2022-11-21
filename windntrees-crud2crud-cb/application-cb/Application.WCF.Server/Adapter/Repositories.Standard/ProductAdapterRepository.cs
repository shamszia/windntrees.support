using System.Collections.Generic;
using WindnTrees.CRUDS.Repository.Standard;
using Application.WCF.Server.DataAccess;
using Application.WCF.Server.Repositories.Standard;

namespace Application.WCF.Server.Adapter.Repositories.Standard
{
    public class ProductAdapterRepository : AdapterServiceRepository<Application.Models.Standard.DataAccess.Adapter.Product, Application.Models.Standard.DataAccess.Product>
    {
        protected override EntityRepository<Application.Models.Standard.DataAccess.Product> GetRepository()
        {
            return new ProductRepository(new ApplicationEntities());
        }

        protected override Application.Models.Standard.DataAccess.Adapter.Product GetAdapterEntity(Application.Models.Standard.DataAccess.Product contentObject)
        {
            return new Application.Models.Standard.DataAccess.Adapter.Product { 
                UID = contentObject.UID,
                Name = contentObject.Name,
                Category = contentObject.Category,
                Code = contentObject.Code,
                Color = contentObject.Color,
                Description = contentObject.Description,
                LegalCode = contentObject.LegalCode,
                Manufacturer = contentObject.Manufacturer,
                Picture = contentObject.Picture,
                ProductYear = contentObject.ProductYear,
                Service = contentObject.Service,
                Unit = contentObject.Unit,
                Version = contentObject.Version,
                RowVersion = contentObject.RowVersion
            };
        }

        protected override Application.Models.Standard.DataAccess.Product GetEFEntity(Application.Models.Standard.DataAccess.Adapter.Product contentObject)
        {
            return new Application.Models.Standard.DataAccess.Product
            {
                UID = contentObject.UID,
                Name = contentObject.Name,
                Category = contentObject.Category,
                Code = contentObject.Code,
                Color = contentObject.Color,
                Description = contentObject.Description,
                LegalCode = contentObject.LegalCode,
                Manufacturer = contentObject.Manufacturer,
                Picture = contentObject.Picture,
                ProductYear = contentObject.ProductYear,
                Service = contentObject.Service,
                Unit = contentObject.Unit,
                Version = contentObject.Version,
                RowVersion = contentObject.RowVersion
            };
        }

        protected override List<Application.Models.Standard.DataAccess.Adapter.Product> GetAdapterList(List<Application.Models.Standard.DataAccess.Product> list)
        {
            var products = new List<Application.Models.Standard.DataAccess.Adapter.Product>();

            foreach(var product in list)
            {
                var adaptedProduct = new Application.Models.Standard.DataAccess.Adapter.Product
                {
                    UID = product.UID,
                    Name = product.Name,
                    Category = product.Category,
                    Code = product.Code,
                    Color = product.Color,
                    Description = product.Description,
                    LegalCode = product.LegalCode,
                    Manufacturer = product.Manufacturer,
                    Picture = product.Picture,
                    ProductYear = product.ProductYear,
                    Service = product.Service,
                    Unit = product.Unit,
                    Version = product.Version,
                    RowVersion = product.RowVersion
                };

                products.Add(adaptedProduct);
            }

            return products;
        }

        protected override List<Application.Models.Standard.DataAccess.Product> GetEFList(List<Application.Models.Standard.DataAccess.Adapter.Product> list)
        {
            var products = new List<Application.Models.Standard.DataAccess.Product>();

            foreach (var product in list)
            {
                var adaptedProduct = new Application.Models.Standard.DataAccess.Product
                {
                    UID = product.UID,
                    Name = product.Name,
                    Category = product.Category,
                    Code = product.Code,
                    Color = product.Color,
                    Description = product.Description,
                    LegalCode = product.LegalCode,
                    Manufacturer = product.Manufacturer,
                    Picture = product.Picture,
                    ProductYear = product.ProductYear,
                    Service = product.Service,
                    Unit = product.Unit,
                    Version = product.Version,
                    RowVersion = product.RowVersion
                };
                products.Add(adaptedProduct);
            }

            return products;
        }
    }
}
