using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(RegistrationMetaData))]
    public partial class Registration
    {

    }

    public partial class RegistrationMetaData
    {
        [Key]
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "UID")]
        public System.Guid UID { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "RegistrationTime")]
        public System.DateTime RegistrationTime { get; set; }

        [LocaleMessageStringLength(128)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "UserID")]
        public string UserID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "FullName")]
        public string FullName { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "Address")]
        public string Address { get; set; }

        [LocaleMessageStringLength(30)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "City")]
        public string City { get; set; }

        [LocaleMessageStringLength(30)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "State")]
        public string State { get; set; }

        [LocaleMessageStringLength(30)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "Country")]
        public string Country { get; set; }

        [LocaleMessageStringLength(10)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "ZipCode")]
        public string ZipCode { get; set; }

        [LocaleMessageStringLength(128)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "Email")]
        public string Email { get; set; }

        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "Phone")]
        public string Phone { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "PCode")]
        public string PCode { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(30)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "HID")]
        public string HID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(10)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "LicenseTypeID")]
        public string LicenseTypeID { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "Period")]
        public Nullable<int> Period { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "CCard")]
        public string CCard { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "CCardYear")]
        public Nullable<int> CCardYear { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "CCardMonth")]
        public Nullable<int> CCardMonth { get; set; }

        [LocaleMessageStringLength(5)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "CVV")]
        public string CVV { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "Cost")]
        public Nullable<int> Cost { get; set; }

        [LocaleMessageStringLength(5)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "CurrencyCode")]
        public string CurrencyCode { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "OrderNumber")]
        public Nullable<long> OrderNumber { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "TransactionID")]
        public Nullable<long> TransactionID { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "Licensed")]
        public Nullable<bool> Licensed { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Product.Registration), Name = "LicenseTime")]
        public Nullable<System.DateTime> LicenseTime { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
