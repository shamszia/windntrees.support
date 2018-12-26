using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    [MetadataType(typeof(LoginHistoryMD))]
    public partial class LoginHistory
    {
        public LoginHistory()
        {

        }

        public LoginHistory(Guid uid, DateTime loginTime, string userID, string ipAddress)
        {
            UID = uid;
            LoginTime = loginTime;
            UserID = userID;
            IP = ipAddress;
        }
    }

    public partial class LoginHistoryMD
    {
        [Key]
        public System.Guid UID { get; set; }
        public Nullable<System.DateTime> LoginTime { get; set; }
        public string UserID { get; set; }
        public string IP { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}