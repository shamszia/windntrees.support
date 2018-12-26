using SharedLibrary.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core.Models
{   
    public partial class UserEditModel
    {
        [Key]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Account.User), Name = "Id")]
        public string UserId { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Account.User), Name = "FirstName")]
        public string FirstName { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Account.User), Name = "LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Account.User), Name = "Sex")]
        public string Sex { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Account.User), Name = "Title")]
        public string Title { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(150)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Account.User), Name = "Email")]
        public string Email { get; set; }

        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Contents.Account.User), Name = "ImageFile")]
        public string ImageFile { get; set; }

    }
}
