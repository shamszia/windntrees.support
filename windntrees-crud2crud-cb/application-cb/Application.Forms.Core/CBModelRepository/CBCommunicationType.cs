using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForms.Core.CBModelRepository
{
    /// <summary>
    /// Defines list of CBRepository communication method types.
    /// </summary>
    public enum CBCommunicationType
    {
        Create = 0,
        Read = 1,
        Update = 2,
        Delete = 3,
        List = 4,
        Method = 5,
        MethodObject = 6
    }
}
