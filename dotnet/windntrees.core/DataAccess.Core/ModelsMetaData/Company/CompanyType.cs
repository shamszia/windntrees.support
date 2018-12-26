using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(CompanyTypeMetaData))]
    public partial class CompanyType
    {

    }

    public partial class CompanyTypeMetaData
    {
        [Key]
        public System.Guid Uid { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.CompanyType), Name = "Name")]
        public string Name { get; set; }


        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.CompanyType), Name = "Description")]
        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
