using SharedLibrary.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    [MetadataType(typeof(AdvertisementLocationMD))]
    public partial class AdvertisementLocation
    {
    }

    public partial class AdvertisementLocationMD
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Category), Name = "Name")]
        public string Name { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Category), Name = "Description")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
