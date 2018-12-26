using SharedLibrary.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    [MetadataType(typeof(ProductFeatureMD))]
    public partial class ProductFeature
    {

    }

    public partial class ProductFeatureMD
    {
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.ProductFeature), Name = "UID")]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.ProductFeature), Name = "ProductID")]
        public Nullable<System.Guid> ProductID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.ProductFeature), Name = "Name")]
        public string Name { get; set; }

        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.ProductFeature), Name = "Description")]
        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
