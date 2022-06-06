using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WindnTrees.CRUDS5.Repository;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;
using WindnTrees.ICRUDS.Standard;

namespace WcfCoreWebApplication
{
    [CoreWCF.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class EmptyDataService : ServiceEmptyRepository<SharedLibrary.Student>
    {
        public EmptyDataService()
            : base(new ApplicationContext(), "")
        {

        }

        public override Student Create()
        {
            return new SharedLibrary.Student { RollNo = "R1", Name = "Shams Zia" };
        }

        public override SharedLibrary.Student Read()
        {
            return new SharedLibrary.Student { RollNo = "R1", Name = "Shams Zia" };
        }

        public override Student Update()
        {
            return new SharedLibrary.Student { RollNo = "R1", Name = "Shams Zia" };
        }

        public override Student Delete()
        {
            return new SharedLibrary.Student { RollNo = "R1", Name = "Shams Zia" };
        }

        public override List<Student> List()
        {
            return new List<Student> { new Student { }, new Student { } };
        }

        public string GetName()
        {
            return "Arshad";
        }
    }
}
