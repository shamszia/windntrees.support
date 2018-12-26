using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;

namespace DataAccess.Core.Poultry
{
    [ModelMetadataType(typeof(TransactionMetaData))]
    public partial class Transaction
    {

    }

    public partial class TransactionMetaData
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "TransactionTime")]
        public System.DateTime TransactionTime { get; set; }

        
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "UpdateTime")]
        public System.DateTime UpdateTime { get; set; }

        
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "ReferenceID")]
        public string ReferenceID { get; set; }

        
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "Reference")]
        public string Reference { get; set; }

        
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "CompositeID")]
        public string CompositeID { get; set; }

        
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "AccountID")]
        public System.Guid AccountID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(20)]
        public string AccountNo { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        public string Title { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(1000)]
        public string Particulars { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "DrAmount")]
        public decimal DrAmount { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "CrAmount")]
        public decimal CrAmount { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "Quantity")]
        public int Quantity { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "Active")]
        public bool Active { get; set; }

        
        [LocaleMessageStringLength(256)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Accounting.Transaction), Name = "Username")]
        public string Username { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
