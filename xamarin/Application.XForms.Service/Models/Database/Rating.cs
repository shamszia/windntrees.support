using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindnTreesSEO.Models.Database
{
    public partial class Rating
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
