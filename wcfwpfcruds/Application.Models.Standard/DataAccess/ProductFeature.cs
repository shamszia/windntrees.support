using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application.Models.Standard.DataAccess
{
    [DataContract]
    public partial class ProductFeature
    {
        [DataMember]
        public System.Guid UID { get; set; }
        [DataMember]
        public Nullable<System.Guid> ProductID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public byte[] RowVersion { get; set; }

        public virtual Product Product { get; set; }
    }
}
