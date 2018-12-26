using SharedLibrary.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    [MetadataType(typeof(CompanyTypeMD))]
    public partial class CompanyType
    {
    }

    public partial class CompanyTypeMD
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Company.CompanyType), Name = "Name")]
        public string Name { get; set; }


        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Company.CompanyType), Name = "Description")]
        public string Description { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
