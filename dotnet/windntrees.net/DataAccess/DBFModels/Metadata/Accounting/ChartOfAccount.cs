using System.ComponentModel.DataAnnotations;
using Abstraction.Attributes;
using SharedLibrary.Attributes;

namespace DataAccess
{
    [MetadataType(typeof(ChartOfAccountMD))]
    public partial class ChartOfAccount
    {

    }

    public partial class ChartOfAccountMD
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(20)]
        //[Display(ResourceType = typeof(LocaleResources.MyAccount.Views.Category.Index), Name = "NameT")]
        public string AccountID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        //[Display(ResourceType = typeof(LocaleResources.MyAccount.Views.Category.Index), Name = "NameT")]
        public string Title { get; set; }

        [LocaleMessageStringLength(255)]
        //[Display(ResourceType = typeof(LocaleResources.MyAccount.Views.Category.Index), Name = "NameT")]
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
