using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Abstraction.Core.Attributes;
using Microsoft.AspNetCore.Identity;

namespace Application.Core.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {   
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [LocaleRequired]
        [LocaleStringLength(100)]
        public string FirstName { get; set; }
        [LocaleStringLength(100)]
        public string LastName { get; set; }
        [LocaleStringLength(10)]
        public string Sex { get; set; }
        [LocaleStringLength(20)]
        public string Title { get; set; }
        [LocaleStringLength(50)]
        public string ImageFile { get; set; }
        [LocaleStringLength(20)]
        public string Package { get; set; }

        [LocaleRequired]
        public DateTime CreationDate { get; set; }

        //if null then account should not expire 
        //otherwise should account for expiry date.
        public Nullable<DateTime> ExpiryDate { get; set; }

        //if null then approved 
        //otherwise account for false value.
        public Boolean IsApproved { get; set; }

        [LocaleStringLength(256)]
        public string ApprovedBy { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
