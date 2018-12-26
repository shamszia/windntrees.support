using Abstraction.Core.Attributes;
using DataAccess.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Core.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [LocaleRequired]
        [LocaleStringLength(150, MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "Email")]
        public string Email { get; set; }

        [LocaleStringLength(150, MinimumLength = 6)]
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "Username")]
        public string UserName { get; set; }

        [LocaleRequired]
        [LocaleStringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [LocaleCompare("Password")]
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [LocaleRequired]
        [LocaleStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "FirstName")]
        public string FirstName { get; set; }

        [LocaleStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "Gender")]
        public string Sex { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "Title")]
        public string Title { get; set; }

        [LocaleStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "ImageFile")]
        public string ImageFile { get; set; }

        [LocaleStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "Package")]
        public string Package { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.DateTime)]
        public System.DateTime ExpiryDate { get; set; }

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        
        [Display(ResourceType = typeof(LocaleResources.Core.Views.Account.Register), Name = "Captcha")]
        public string Captcha { get; set; }


        public virtual ICollection<AspNetRoles> Roles { get; set; }
    }
}
