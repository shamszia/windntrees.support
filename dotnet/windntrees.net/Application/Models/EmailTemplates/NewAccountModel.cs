using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models.EmailTemplates
{
    public class NewAccountModel
    {
        public string Title { get; set; }
        public string FullName { get; set; }
        public string ActivationLink { get; set; }
        public string Company { get; set; }
        public string UnsubscriptionEmail { get; set; }
    }
}