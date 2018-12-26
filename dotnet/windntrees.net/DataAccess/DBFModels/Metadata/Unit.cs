using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess
{
    [MetadataType(typeof(UnitMD))]
    public partial class Unit
    {

    }

    public partial class UnitMD
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Unit), Name = "Name")]
        public string Name { get; set; }


        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Unit), Name = "Description")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
