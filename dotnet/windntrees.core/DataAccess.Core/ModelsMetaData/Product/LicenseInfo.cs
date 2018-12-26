using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(LicenseInfoMetaData))]
    public partial class LicenseInfo
    {

    }

    public partial class LicenseInfoMetaData
    {
        [Key]
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.LicenseInfo), Name = "ProductID")]
        public System.Guid ProductId { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.LicenseInfo), Name = "Code")]
        public string Code { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


        public virtual Product Product { get; set; }
    }
}
