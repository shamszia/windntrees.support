using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(CompanyMetaData))]
    public partial class Company
    {

    }

    public partial class CompanyMetaData
    {
        [Key]
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "UID")]
        public System.Guid Uid { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "LegalCode")]
        public string LegalCode { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "NTN")]
        public string Ntn { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "STRN")]
        public string Strn { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "LegalName")]
        public string LegalName { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "CompanyType")]
        public string CompanyType { get; set; }

        [LocaleMessageStringLength(1024)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Description")]
        public string Description { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Director")]
        public string Director { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Secretary")]
        public string Secretary { get; set; }

        [LocaleMessageStringLength(255)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Address")]
        public string Address { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "City")]
        public string City { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "State")]
        public string State { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Country")]
        public string Country { get; set; }

        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Phone1")]
        public string Phone1 { get; set; }

        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Phone2")]
        public string Phone2 { get; set; }

        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Cell1")]
        public string Cell1 { get; set; }

        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Cell2")]
        public string Cell2 { get; set; }

        [LocaleMessageStringLength(128)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Email")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "PaidUpCapital")]
        public Nullable<long> PaidUpCapital { get; set; }

        [LocaleMessageStringLength(10)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "Currency")]
        public string Currency { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "ContactPerson")]
        public string ContactPerson { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "ContactPersonDesignation")]
        public string ContactPersonDesignation { get; set; }

        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "ContactPersonPhone")]
        public string ContactPersonPhone { get; set; }

        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "ContactPersonCell")]
        public string ContactPersonCell { get; set; }

        [LocaleMessageStringLength(128)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Company.Company), Name = "ContactPersonEmail")]
        public string ContactPersonEmail { get; set; }

        public bool Enabled { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
