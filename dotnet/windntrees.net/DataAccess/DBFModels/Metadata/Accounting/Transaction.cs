using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess
{
    [MetadataType(typeof(TransactionMD))]
    public partial class Transaction
    {

    }

    public partial class TransactionMD
    {
        [Key]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "UID")]
        public System.Guid CompositeUID { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "TransactionTime")]
        public System.DateTime TransactionTime { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "AccountID")]
        public string AccountID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "Title")]
        public string Title { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(1500)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "Particulars")]
        public string Particulars { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "DrAmount")]
        public decimal DrAmount { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "CrAmount")]
        public decimal CrAmount { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "Quantity")]
        public int Quantity { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Accounting.Transaction), Name = "Active")]
        public bool Active { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
