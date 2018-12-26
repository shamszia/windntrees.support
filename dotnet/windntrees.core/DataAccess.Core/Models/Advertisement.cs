using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class Advertisement
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [Required]
        [StringLength(1024)]
        public string Detail { get; set; }
        public bool? Enabled { get; set; }
        [Required]
        [StringLength(100)]
        public string Heading { get; set; }
        [StringLength(512)]
        public string Link1 { get; set; }
        [StringLength(512)]
        public string Link2 { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        public bool? News { get; set; }
        [StringLength(50)]
        public string Page { get; set; }
        [StringLength(50)]
        public string Picture { get; set; }
        public DateTime RecordTime { get; set; }
        [Column("ReferenceID")]
        public Guid? ReferenceId { get; set; }
        public byte[] RowVersion { get; set; }
        public int? SortOrder { get; set; }
        [StringLength(100)]
        public string Source { get; set; }
        [StringLength(100)]
        public string SubHeading { get; set; }
        public DateTime? UpdateTime { get; set; }
        [StringLength(50)]
        public string Video { get; set; }
    }
}
