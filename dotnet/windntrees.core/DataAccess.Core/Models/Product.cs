using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductFeature = new HashSet<ProductFeature>();
        }

        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        public string Category { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        public string Color { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        [StringLength(100)]
        public string LegalCode { get; set; }
        public string Manufacturer { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Picture { get; set; }
        public int? ProductYear { get; set; }
        public byte[] RowVersion { get; set; }
        public bool? Service { get; set; }
        public string Unit { get; set; }
        [StringLength(100)]
        public string Version { get; set; }

        [InverseProperty("Product")]
        public LicenseInfo LicenseInfo { get; set; }
        [InverseProperty("Product")]
        public ICollection<ProductFeature> ProductFeature { get; set; }
    }
}
