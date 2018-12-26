using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess
{
    [MetadataType(typeof(UserMD))]
    public partial class User
    {
        public string Password { get; set; }

    }   

    public class UserMD
    {
        [Key]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "UserId")]
        public string UserId { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "FirstName")]
        public string FirstName { get; set; }
        
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "Sex")]
        public string Sex { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "Title")]
        public string Title { get; set; }

        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "ImageFile")]
        public string ImageFile { get; set; }

        [LocaleMessageStringLength(20)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "Package")]
        public string Package { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "CreationDate")]
        public Nullable<System.DateTime> CreationDate { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "ExpiryDate")]
        public Nullable<System.DateTime> ExpiryDate { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "IsApproved")]
        public Nullable<bool> IsApproved { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "ApprovedBy")]
        public string ApprovedBy { get; set; }

        public virtual ICollection<UserClaim> UserClaims { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }

    public partial class UserEditModel
    {
        [Key]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "UserId")]
        public string UserId { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "FirstName")]
        public string FirstName { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "Sex")]
        public string Sex { get; set; }

        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "Title")]
        public string Title { get; set; }

        [LocaleMessageRequired]
        [LocaleMessageStringLength(150)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "Email")]
        public string Email { get; set; }

        [LocaleMessageStringLength(50)]
        [Display(ResourceType = typeof(LocaleResources.Contents.Account.User), Name = "ImageFile")]
        public string ImageFile { get; set; }

    }

    public class UserRecord
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Title { get; set; }
        public string ImageFile { get; set; }
        public string Package { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public string ApprovedBy { get; set; }

        public virtual ICollection<RoleRecord> Roles { get; set; }
    }

    public class RoleRecord
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
    }
}
