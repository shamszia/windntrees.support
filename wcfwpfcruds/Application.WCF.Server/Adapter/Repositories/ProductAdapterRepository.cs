using Application.Models.Standard.DataAccess.Adapter;
using Application.WCF.Server.DataAccess;
using Application.WCF.Server.Repositories;
using System.Collections.Generic;
using WindnTrees.CRUDS.Repository;

namespace Application.WCF.Server.Adapter.Repositories
{
    public class ProductAdapterRepository : AdapterServiceRepository<Application.Models.Standard.DataAccess.Adapter.Product, Application.Models.Standard.DataAccess.Product>
    {
        protected override EntityRepository<Application.Models.Standard.DataAccess.Product> GetRepository()
        {
            return new ProductRepository(new ApplicationEntities());
        }

        protected override Application.Models.Standard.DataAccess.Adapter.Product GetAdapterEntity(Application.Models.Standard.DataAccess.Product contentObject)
        {
            var adapterProductFeatures = new List<Application.Models.Standard.DataAccess.Adapter.ProductFeature>();
            if (contentObject.ProductFeatures != null)
            {
                foreach(var feature in contentObject.ProductFeatures)
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
                RowVersion = contentObject.RowVersion,
                ProductFeatures = adapterProductFeatures
            };
        }

        protected override Application.Models.Standard.DataAccess.Product GetEFEntity(Application.Models.Standard.DataAccess.Adapter.Product contentObject)
        {
            var efProductFeatures = new List<Application.Models.Standard.DataAccess.ProductFeature>();
            if (contentObject.ProductFeatures != null)
            {
                foreach (var feature in ((List<Application.Models.Standard.DataAccess.Adapter.ProductFeature>)contentObject.ProductFeatures))
                {
                    efProductFeatures.Add(new Application.Models.Standard.DataAccess.ProductFeature
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
                RowVersion = contentObject.RowVersion,
                ProductFeatures = efProductFeatures
            };
        }

        protected override List<Application.Models.Standard.DataAccess.Adapter.Product> GetAdapterList(List<Application.Models.Standard.DataAccess.Product> list)
        {
            var adapterProducts = new List<Application.Models.Standard.DataAccess.Adapter.Product>();

            foreach(var efProduct in list)
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

        protected override List<Application.Models.Standard.DataAccess.Product> GetEFList(List<Application.Models.Standard.DataAccess.Adapter.Product> list)
        {
            var efProducts = new List<Application.Models.Standard.DataAccess.Product>();

            foreach (var product in list)
            {
                var efProductFeatures = new List<Application.Models.Standard.DataAccess.ProductFeature>();
                if (product.ProductFeatures != null)
                {
                    foreach (var feature in ((List<Application.Models.Standard.DataAccess.Adapter.ProductFeature>)product.ProductFeatures))
                    {
                        efProductFeatures.Add(new Application.Models.Standard.DataAccess.ProductFeature
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

                var efProduct = new Application.Models.Standard.DataAccess.Product
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
                    RowVersion = product.RowVersion,
                    ProductFeatures = efProductFeatures
                };
                efProducts.Add(efProduct);
            }

            return efProducts;
        }


    }
}