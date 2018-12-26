using Abstraction.Core.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(AspNetUsersMetaData))]
    public partial class AspNetUsers
    {

    }

    public class AspNetUsersMetaData
    {
        [Key]
        [LocaleStringLength(450)]
        public string Id { get; set; }

        public string UserName { get; set; }

        [LocaleStringLength(256)]
        public string ConcurrencyStamp { get; set; }
        [LocaleStringLength(256)]
        public string Email { get; set; }
        [LocaleStringLength(256)]
        public string NormalizedEmail { get; set; }
        [LocaleStringLength(256)]
        public string NormalizedUserName { get; set; }

        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset LockoutEnd { get; set; }

        public int AccessFailedCount { get; set; }
        public string SecurityStamp { get; set; }


        //Extended Application UserFields.

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
    }
}
