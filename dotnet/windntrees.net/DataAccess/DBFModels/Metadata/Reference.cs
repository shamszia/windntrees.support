using SharedLibrary.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    [MetadataType(typeof(ReferenceMD))]
    public partial class Reference
    {

    }

    public partial class ReferenceMD
    {
        [LocaleMessageRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "UID")]
        public System.Guid UID { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "ReferenceID")]
        public Nullable<System.Guid> ReferenceID { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "Name")]
        public string Name { get; set; }

        [LocaleMessageStringLength(1024)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "Description")]
        public string Description { get; set; }

        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "ContentFile")]
        public string ContentFile { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "Size")]
        public long Size { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "Readable")]
        public Nullable<bool> Readable { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "Picture")]
        public Nullable<bool> Picture { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "AudioVideo")]
        public Nullable<bool> AudioVideo { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Reference), Name = "Download")]
        public bool Download { get; set; }

        public byte[] RowVersion { get; set; }
    }
}