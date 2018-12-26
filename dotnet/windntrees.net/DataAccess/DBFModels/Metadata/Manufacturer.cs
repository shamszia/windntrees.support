using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess
{
    [MetadataType(typeof(ManufacturerMD))]
    public partial class Manufacturer
    {

    }

    public partial class ManufacturerMD
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Manufacturer), Name = "Name")]
        public string Name { get; set; }


        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Manufacturer), Name = "Description")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
