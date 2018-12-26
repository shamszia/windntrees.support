using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Core.Models
{
    public partial class Registration
    {
        [Key]
        [Column("UID")]
        public Guid Uid { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [Column("CCard")]
        [StringLength(20)]
        public string Ccard { get; set; }
        [Column("CCardMonth")]
        public int? CcardMonth { get; set; }
        [Column("CCardYear")]
        public int? CcardYear { get; set; }
        [Column("CVV")]
        [StringLength(5)]
        public string Cvv { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        public int? Cost { get; set; }
        [StringLength(30)]
        public string Country { get; set; }
        [StringLength(5)]
        public string CurrencyCode { get; set; }
        [StringLength(128)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [Column("HID")]
        [StringLength(30)]
        public string Hid { get; set; }
        public DateTime? LicenseTime { get; set; }
        [Required]
        [Column("LicenseTypeID")]
        [StringLength(10)]
        public string LicenseTypeId { get; set; }
        public bool? Licensed { get; set; }
        public long? OrderNumber { get; set; }
        [Required]
        [Column("PCode")]
        [StringLength(100)]
        public string Pcode { get; set; }
        public int Period { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public DateTime RegistrationTime { get; set; }
        public byte[] RowVersion { get; set; }
        [StringLength(30)]
        public string State { get; set; }
        [Column("TransactionID")]
        public long? TransactionId { get; set; }
        [Column("UserID")]
        [StringLength(128)]
        public string UserId { get; set; }
        [StringLength(10)]
        public string ZipCode { get; set; }
    }
}
