using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(ConfigurationMetaData))]
    public partial class Configuration
    {

    }

    public partial class ConfigurationMetaData
    {
        [Key]
        public System.Guid Uid { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Configuration), Name = "Key")]
        public string KeyParam { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(1500)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Configuration), Name = "Value")]
        public string ValParam { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
