using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core.Models
{
    public class ApplicationRole : IdentityRole
    {   
        public ApplicationRole()
        {

        }

        public ApplicationRole (string roleName) 
            : base(roleName)
        {

        }

        //public virtual ICollection<IdentityUserRole<string>> Users { get; set; }
    }
}
