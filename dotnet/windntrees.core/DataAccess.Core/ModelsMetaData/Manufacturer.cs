using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(ManufacturerMetaData))]
    public partial class Manufacturer
    {

    }

    public partial class ManufacturerMetaData
    {
        [Key]
        public System.Guid Uid { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Manufacturer), Name = "Name")]
        public string Name { get; set; }


        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Manufacturer), Name = "Description")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
