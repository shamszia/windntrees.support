using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application.Models.Standard.DataAccess.Adapter
{
    [DataContract]
    [KnownType(typeof(List<ProductFeature>))]
    public class Product
    {
        [DataMember]
        public System.Guid UID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string LegalCode { get; set; }
        [DataMember]
        public Nullable<int> ProductYear { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public Nullable<bool> Service { get; set; }
        [DataMember]
        public string Picture { get; set; }
        [DataMember]
        public byte[] RowVersion { get; set; }
        [DataMember]
        public object ProductFeatures = new List<ProductFeature>();
    }
}
