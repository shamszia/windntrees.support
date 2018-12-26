using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess.DBFModels.Metadata
{
    [MetadataType(typeof(ColorMD))]
    public partial class Color
    {

    }

    public partial class ColorMD
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(10)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Color), Name = "Name")]
        public string Name { get; set; }

        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Color), Name = "Description")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
