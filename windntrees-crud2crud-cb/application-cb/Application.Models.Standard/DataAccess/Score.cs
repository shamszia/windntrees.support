using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Standard.DataAccess
{
    /// <summary>
    /// Score class to elaborate callback repository implementation. 
    /// It is not part of database.
    /// </summary>
    public class Score
    {
        public string ClientID { get; set; }
        public float ScoreResult { get; set; }
    }
}
