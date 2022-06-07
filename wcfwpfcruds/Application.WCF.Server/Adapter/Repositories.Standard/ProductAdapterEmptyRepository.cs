using System.Collections.Generic;
using Application.WCF.Server.DataAccess;
using Application.WCF.Server.Repositories.Standard;
using WindnTrees.CRUDS.Repository.Standard;

namespace Application.WCF.Server.Adapter.Repositories.Standard
{
    public class ProductAdapterEmptyRepository : AdapterEmptyServiceRepository<Application.Models.Standard.DataAccess.Adapter.Product, Application.Models.Standard.DataAccess.Product>
    {
        protected override EntityEmptyRepository<Application.Models.Standard.DataAccess.Product> GetRepository()
        {
            return new ProductEmptyRepository(new ApplicationEntities());
        }

        protected override Application.Models.Standard.DataAccess.Adapter.Product GetAdapterEntity(Application.Models.Standard.DataAccess.Product contentObject)
        {
            var adapterProductFeatures = new List<Application.Models.Standard.DataAccess.Adapter.ProductFeature>();
            if (contentObject.ProductFeatures != null)
            {
                foreach (var feature in contentObject.ProductFeatures)
                {
                    adapterProductFeatures.Add(new Application.Models.Standard.DataAccess.Adapter.ProductFeature
                    {
                        UID = feature.UID,
                        Name = feature.Name,
                        Description = feature.Description,
                        ProductID = feature.ProductID,
                        RowVersion = feature.RowVersion,
                        Product = null
                    });
                }
            }

            return new Application.Models.Standard.DataAccess.Adapter.Product
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
                RowVersion = contentObject.RowVersion,
                ProductFeatures = adapterProductFeatures
            };
        }

        protected override List<Application.Models.Standard.DataAccess.Adapter.Product> GetAdapterList(List<Application.Models.Standard.DataAccess.Product> list)
        {
            var adapterProducts = new List<Application.Models.Standard.DataAccess.Adapter.Product>();

            foreach (var efProduct in list)
            {
                var adapterProductFeatures = new List<Application.Models.Standard.DataAccess.Adapter.ProductFeature>();
                if (efProduct.ProductFeatures != null)
                {
                    foreach (var feature in efProduct.ProductFeatures)
                    {
                        adapterProductFeatures.Add(new Application.Models.Standard.DataAccess.Adapter.ProductFeature
                        {
                            UID = feature.UID,
                            Name = feature.Name,
                            Description = feature.Description,
                            ProductID = feature.ProductID,
                            RowVersion = feature.RowVersion,
                            Product = null
                        });
                    }
                }

                var adapterProduct = new Application.Models.Standard.DataAccess.Adapter.Product
                {
                    UID = efProduct.UID,
                    Name = efProduct.Name,
                    Category = efProduct.Category,
                    Code = efProduct.Code,
                    Color = efProduct.Color,
                    Description = efProduct.Description,
                    LegalCode = efProduct.LegalCode,
                    Manufacturer = efProduct.Manufacturer,
                    Picture = efProduct.Picture,
                    ProductYear = efProduct.ProductYear,
                    Service = efProduct.Service,
                    Unit = efProduct.Unit,
                    Version = efProduct.Version,
                    RowVersion = efProduct.RowVersion,
                    ProductFeatures = adapterProductFeatures
                };
                adapterProducts.Add(adapterProduct);
            }

            return adapterProducts;
        }
    }
}
