//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginHistory
    {
        public System.Guid UID { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public string UserID { get; set; }
        public string IP { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
