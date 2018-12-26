using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class ProductFeature
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column("ProductID")]
        public Guid ProductId { get; set; }
        public byte[] RowVersion { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("ProductFeature")]
        public Product Product { get; set; }
    }
}
