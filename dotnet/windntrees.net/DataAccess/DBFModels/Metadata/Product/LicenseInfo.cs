using SharedLibrary.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    [MetadataType(typeof(LicenseInfoMD))]
    public partial class LicenseInfo
    {

    }

    public partial class LicenseInfoMD
    {
        [Key]
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.LicenseInfo), Name = "ProductID")]
        public System.Guid ProductID { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Product.LicenseInfo), Name = "Code")]
        public string Code { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
