using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess.Models
{
    public partial class Email
    {
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "FromName")]
        public string FromName { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(150)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "FromEmail")]
        public string FromEmail { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(150)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "ToEmail")]
        public string ToEmail { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "Subject")]
        public string Subject { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(4000)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "Message")]
        public string Message { get; set; }
    }
}
