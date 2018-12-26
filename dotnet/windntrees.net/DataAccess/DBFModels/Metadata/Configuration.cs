using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess.DBFModels.Metadata
{
    [MetadataType(typeof(ConfigurationMD))]
    public partial class Configuration
    {

    }

    public partial class ConfigurationMD
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Configuration), Name = "Key")]
        public string KeyParam { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(1500)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Configuration), Name = "Value")]
        public string ValParam { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
