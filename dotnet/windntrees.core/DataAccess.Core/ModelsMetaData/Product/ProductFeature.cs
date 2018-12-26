using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(ProductFeatureMetaData))]
    public partial class ProductFeature
    {

    }

    public partial class ProductFeatureMetaData
    {
        [Key]
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.ProductFeature), Name = "UID")]
        public System.Guid Uid { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.ProductFeature), Name = "ProductID")]
        public Nullable<System.Guid> ProductId { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.ProductFeature), Name = "Name")]
        public string Name { get; set; }

        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.ProductFeature), Name = "Description")]
        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
