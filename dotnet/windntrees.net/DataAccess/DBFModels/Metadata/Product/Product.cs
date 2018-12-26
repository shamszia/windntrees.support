using System;
using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess
{
    [MetadataType(typeof(ProductMD))]
    public partial class Product
    {

    }

    public partial class ProductMD
    {

        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Name")]
        public string Name { get; set; }

        [LocaleMessageStringLength(1024)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Description")]
        public string Description { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Version")]
        public string Version { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Code")]
        public string Code { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "LegalCode")]
        public string LegalCode { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "ProductYear")]
        public Nullable<int> ProductYear { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Category")]
        public string Category { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Unit")]
        public string Unit { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Color")]
        public string Color { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Service")]
        public Nullable<bool> Service { get; set; }

        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.Product), Name = "Picture")]
        public string Picture { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
