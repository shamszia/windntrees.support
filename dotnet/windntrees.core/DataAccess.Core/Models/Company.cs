using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class Company
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(20)]
        public string Cell1 { get; set; }
        [StringLength(20)]
        public string Cell2 { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyType { get; set; }
        [StringLength(100)]
        public string ContactPerson { get; set; }
        [StringLength(20)]
        public string ContactPersonCell { get; set; }
        [StringLength(100)]
        public string ContactPersonDesignation { get; set; }
        [StringLength(128)]
        public string ContactPersonEmail { get; set; }
        [StringLength(20)]
        public string ContactPersonPhone { get; set; }
        [StringLength(100)]
        public string Country { get; set; }
        [StringLength(10)]
        public string Currency { get; set; }
        [StringLength(1024)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Director { get; set; }
        [StringLength(128)]
        public string Email { get; set; }
        public bool Enabled { get; set; }
        [Required]
        [StringLength(100)]
        public string LegalCode { get; set; }
        [Required]
        [StringLength(255)]
        public string LegalName { get; set; }
        [Column("NTN")]
        [StringLength(100)]
        public string Ntn { get; set; }
        public long? PaidUpCapital { get; set; }
        [StringLength(20)]
        public string Phone1 { get; set; }
        [StringLength(20)]
        public string Phone2 { get; set; }
        public byte[] RowVersion { get; set; }
        [Column("STRN")]
        [StringLength(100)]
        public string Strn { get; set; }
        [StringLength(100)]
        public string Secretary { get; set; }
        [StringLength(100)]
        public string State { get; set; }
    }
}
