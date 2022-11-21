using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WCF.Server
{
    public class CBRepositorySubscriptionObject
    {
        public string ID { get; set; }
        public object Repository { get; set; }
        public bool CallbackInvoked { get; set; }

        public CBRepositorySubscriptionObject()
        {
            CallbackInvoked = false;
        }
    }
}
