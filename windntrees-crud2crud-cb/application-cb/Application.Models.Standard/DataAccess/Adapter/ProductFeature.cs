using System;
using System.Runtime.Serialization;

namespace Application.Models.Standard.DataAccess.Adapter
{
    [DataContract]
    [KnownType(typeof(Product))]
    public class ProductFeature
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
        [DataMember]
        public object Product = new Product();
    }
}
