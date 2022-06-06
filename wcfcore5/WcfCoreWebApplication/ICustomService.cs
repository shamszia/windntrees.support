using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindnTrees.ICRUDS.Standard;
using System.ServiceModel;

namespace WcfCoreWebApplication
{   
    public interface ICustomService<T> : IWCFService<T> where T : class
    {
    }
}
