using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(ReferenceMetaData))]
    public partial class Reference
    {

    }

    public partial class ReferenceMetaData
    {
        [Key]
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "UID")]
        public System.Guid Uid { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "ReferenceID")]
        public Nullable<System.Guid> ReferenceId { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "Name")]
        public string Name { get; set; }

        [LocaleMessageStringLength(1024)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "Description")]
        public string Description { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "ContentFile")]
        public string ContentFile { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "Size")]
        public long Size { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "Readable")]
        public Nullable<bool> Readable { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "Picture")]
        public Nullable<bool> Picture { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "AudioVideo")]
        public Nullable<bool> AudioVideo { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Reference), Name = "Download")]
        public bool Download { get; set; }

        public byte[] ContentBytes { get; set; }

        public byte[] RowVersion { get; set; }
    }
}