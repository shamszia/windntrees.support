using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class Configuration
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [Required]
        [StringLength(50)]
        public string KeyParam { get; set; }
        public byte[] RowVersion { get; set; }
        [Required]
        [StringLength(1500)]
        public string ValParam { get; set; }
    }
}
