using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core.Models
{
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
}
