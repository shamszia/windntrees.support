using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class Reference
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        public bool? AudioVideo { get; set; }
        public byte[] ContentBytes { get; set; }
        [StringLength(100)]
        public string ContentFile { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        public bool Download { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool? Picture { get; set; }
        public bool? Readable { get; set; }
        [Column("ReferenceID")]
        public Guid? ReferenceId { get; set; }
        public byte[] RowVersion { get; set; }
        public long Size { get; set; }
    }
}
