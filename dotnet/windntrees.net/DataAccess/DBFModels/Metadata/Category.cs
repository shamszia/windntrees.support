using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess
{
    [MetadataType(typeof(CategoryMD))]
    public partial class Category
    {

    }

    public partial class CategoryMD
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
