﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class Category
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
    }
}