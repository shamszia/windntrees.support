using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(AdvertisementMetaData))]
    public partial class Advertisement
    {

    }

    public partial class AdvertisementMetaData
    {
        [Key]
        public System.Guid Uid { get; set; }

        public Nullable<Guid> ReferenceId { get; set; }

        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "RecordTime")]
        public System.DateTime RecordTime { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "UpdateTime")]
        public Nullable<System.DateTime> UpdateTime { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Heading")]
        public string Heading { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "SubHeading")]
        public string SubHeading { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(1024)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Detail")]
        public string Detail { get; set; }

        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Picture")]
        public string Picture { get; set; }

        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Video")]
        public string Video { get; set; }

        [LocaleMessageStringLength(512)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Link1")]
        public string Link1 { get; set; }

        [LocaleMessageStringLength(512)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Link2")]
        public string Link2 { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Source")]
        public string Source { get; set; }

        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Page")]
        public string Page { get; set; }

        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Location")]
        public string Location { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "SortOrder")]
        public Nullable<int> SortOrder { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "News")]
        public Nullable<bool> News { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Advertisement), Name = "Enabled")]
        public Nullable<bool> Enabled { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
