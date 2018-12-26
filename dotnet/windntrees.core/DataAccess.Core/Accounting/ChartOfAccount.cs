using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;
using System.ComponentModel.DataAnnotations;


namespace DataAccess.Core.Poultry
{
    [ModelMetadataType(typeof(ChartOfAccountMetaData))]
    public partial class ChartOfAccount
    {

    }

    public partial class ChartOfAccountMetaData
    {
        [Key]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.ChartOfAccount), Name = "UID")]
        public System.Guid Uid { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.ChartOfAccount), Name = "Account")]
        public string Account { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.ChartOfAccount), Name = "Title")]
        public string Title { get; set; }

        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.ChartOfAccount), Name = "Description")]
        public string Description { get; set; }

        [Timestamp]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.ChartOfAccount), Name = "RowVersion")]
        public byte[] RowVersion { get; set; }
    }
}
