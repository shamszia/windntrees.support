using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        [StringLength(256)]
        public string ApprovedBy { get; set; }
        public string ConcurrencyStamp { get; set; }
        public DateTime CreationDate { get; set; }
        [StringLength(256)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime? ExpiryDate { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string ImageFile { get; set; }
        public bool IsApproved { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        [StringLength(256)]
        public string NormalizedEmail { get; set; }
        [StringLength(256)]
        public string NormalizedUserName { get; set; }
        [StringLength(20)]
        public string Package { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        [StringLength(10)]
        public string Sex { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        public bool TwoFactorEnabled { get; set; }
        [StringLength(256)]
        public string UserName { get; set; }

        [InverseProperty("User")]
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
