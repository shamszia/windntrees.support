using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Core.Attributes;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(EmailMetaData))]
    public partial class Email
    {   
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Captcha { get; set; }
    }

    public partial class EmailMetaData
    {
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Email), Name = "FromName")]
        public string FromName { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(150)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Email), Name = "FromEmail")]
        public string FromEmail { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Email), Name = "Subject")]
        public string Subject { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(4000)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Email), Name = "Message")]
        public string Message { get; set; }

        public string Captcha { get; set; }
    }
}
