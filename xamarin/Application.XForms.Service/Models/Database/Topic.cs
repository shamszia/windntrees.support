using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindnTreesSEO.Models.Database
{
    public partial class Topic
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [Column("CategoryID")]
        public Guid CategoryId { get; set; }
        [Column("SkillLevelID")]
        public Guid? SkillLevelId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RecordTime { get; set; }
        [StringLength(100)]
        public string Menu { get; set; }
        [Required]
        [StringLength(200)]
        public string Subject { get; set; }
        [Column(TypeName = "ntext")]
        public string Description1 { get; set; }
        [Column(TypeName = "ntext")]
        public string Description2 { get; set; }
        public bool? Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateTime { get; set; }
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Topic")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(SkillLevelId))]
        [InverseProperty("Topic")]
        public virtual SkillLevel SkillLevel { get; set; }
    }
}
