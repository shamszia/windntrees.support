using Abstraction.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [LocaleRequired]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Login), Name = "UserName")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [LocaleRequired]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.ResetPasswordConfirm), Name = "CurrentPassword")]
        public string OldPassword { get; set; }

        [LocaleRequired]
        [LocaleStringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.ResetPasswordConfirm), Name = "Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [LocaleCompare("NewPassword")]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.ResetPasswordConfirm), Name = "Confirm")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [LocaleRequired]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Login), Name = "Username")]
        public string UserName { get; set; }

        [LocaleRequired]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Login), Name = "Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Views.Account.Login), Name = "SignInBox")]
        public bool RememberMe { get; set; }

        [LocaleRequired]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Login), Name = "Captcha")]
        public string Captcha { get; set; }
    }

    public class RegisterViewModel
    {

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "UserId")]
        public string UserId { get; set; }

        [LocaleRequired]
        [LocaleStringLength(64, MinimumLength = 6)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "Username")]
        public string UserName { get; set; }

        [LocaleRequired]
        [LocaleStringLength(32, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [LocaleCompare("Password")]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [LocaleRequired]
        [LocaleStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "FirstName")]
        public string FirstName { get; set; }

        [LocaleStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "Gender")]
        public string Sex { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "Title")]
        public string Title { get; set; }

        [LocaleStringLength(150)]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "Email")]
        public string Email { get; set; }

        [LocaleStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "ImageFile")]
        public string ImageFile { get; set; }

        [LocaleStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "Package")]
        public string Package { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.DateTime)]
        public System.DateTime ExpiryDate { get; set; }

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }

        [LocaleRequired]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.Register), Name = "Captcha")]
        public string Captcha { get; set; }
    }

    public class UserRole
    {
        [LocaleRequired]
        public int UserId { get; set; }
        public string UserName { get; set; }
        [LocaleRequired]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Allowed { get; set; }
    }

    public class LocalPasswordModel
    {
        [LocaleRequired]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [LocaleRequired]
        [LocaleStringLength(32, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordModel
    {
        [LocaleRequired]
        [LocaleStringLength(32, MinimumLength = 6)]
        public string UserName { get; set; }
    }

    public class ResetPasswordConfirmModel
    {
        [LocaleRequired]
        public string Token { get; set; }

        [LocaleRequired]
        public string UserId { get; set; }


        [LocaleRequired]
        [DataType(DataType.Password)]
        [LocaleStringLength(32, MinimumLength = 8)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.ResetPasswordConfirm), Name = "Password")]
        public string NewPassword { get; set; }

        [LocaleRequired]
        [LocaleCompare("NewPassword")]
        [LocaleStringLength(32, MinimumLength = 8)]
        [Display(ResourceType = typeof(LocaleResources.Views.Account.ResetPasswordConfirm), Name = "Confirm")]
        public string ConfirmPassword { get; set; }
    }

    public class GeneralEmail
    {
        [LocaleStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "FromName")]
        public string FromName { get; set; }

        [LocaleRequired]
        [LocaleStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "FromEmail")]
        public string FromEmail { get; set; }

        [LocaleRequired]
        [LocaleStringLength(100)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "Subject")]
        public string Subject { get; set; }

        [LocaleRequired]
        [LocaleStringLength(500)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "Message")]
        public string Message { get; set; }

        [LocaleRequired]
        [Display(ResourceType = typeof(LocaleResources.Contents.Email), Name = "Captcha")]
        public string Captcha { get; set; }
    }
}