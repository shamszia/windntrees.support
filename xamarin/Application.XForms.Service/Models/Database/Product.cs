using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindnTreesSEO.Models.Database
{
    public partial class Product
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Version { get; set; }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(100)]
        public string LegalCode { get; set; }
        public int? ProductYear { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        [StringLength(50)]
        public string Manufacturer { get; set; }
        [StringLength(50)]
        public string Unit { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public bool? Service { get; set; }
        [StringLength(50)]
        public string Picture { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
