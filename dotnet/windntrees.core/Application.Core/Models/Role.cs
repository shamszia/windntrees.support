using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedLibrary.Core.Attributes;

namespace Application.Core.Models
{
    public class Role
    {
        [LocaleMessageRequired]
        public string RoleId { get; set; }
        [LocaleMessageRequired]
        public string Name { get; set; }

        public string ConcurrencyStamp { get; set; }
        public string NormalizedName { get; set; }
    }
}