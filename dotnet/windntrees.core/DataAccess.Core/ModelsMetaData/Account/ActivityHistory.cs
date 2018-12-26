using Abstraction.Core.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Core.Models
{
    [ModelMetadataType(typeof(ActivityHistoryMetaData))]
    public partial class ActivityHistory
    {

    }

    public partial class ActivityHistoryMetaData
    {
        [Key]
        public System.Guid Uid { get; set; }

        public Nullable<System.DateTime> ActivityTime { get; set; }

        [LocaleStringLength(100)]
        public string Activity { get; set; }

        [LocaleStringLength(2048)]
        public string Request { get; set; }

        public string UserId { get; set; }
        public string Ipaddress { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}