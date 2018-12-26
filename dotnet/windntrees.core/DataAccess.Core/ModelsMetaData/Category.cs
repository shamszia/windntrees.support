using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {

    }

    public partial class CategoryMetaData
    {
        [Key]
        public System.Guid Uid { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Category), Name = "Name")]
        public string Name { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Category), Name = "Description")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
