using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class LicenseInfo
    {
        [Key]
        [Column("ProductID")]
        public Guid ProductId { get; set; }
        [Required]
        public string Code { get; set; }
        public byte[] RowVersion { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("LicenseInfo")]
        public Product Product { get; set; }
    }
}
