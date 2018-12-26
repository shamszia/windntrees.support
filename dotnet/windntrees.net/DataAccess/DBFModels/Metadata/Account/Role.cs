using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SharedLibrary.Attributes;

namespace DataAccess.DBFModels.Metadata
{
    [MetadataType(typeof(RoleMD))]
    public partial class Role
    { }

    public class RoleMD
    {

        [LocaleMessageRequired]
        public string RoleId { get; set; }
        [LocaleMessageRequired]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
