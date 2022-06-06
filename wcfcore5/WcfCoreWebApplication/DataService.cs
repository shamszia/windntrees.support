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
    public class DataService : ServiceRepository<SharedLibrary.Student>
    {
        public DataService()
            : base(new ApplicationContext(), "")
        {

        }

        public override Student Create(Student contentObject)
        {
            return new SharedLibrary.Student { RollNo = "R1", Name = "Shams Zia" };
        }

        public override SharedLibrary.Student Read(object id)
        {
            return new SharedLibrary.Student { RollNo = "R1", Name = "Shams Zia" };
        }

        public override Student Update(Student contentObject)
        {
            return new SharedLibrary.Student { RollNo = "R1", Name = "Shams Zia" };
        }

        public override Student Delete(Student contentObject)
        {
            return new SharedLibrary.Student { RollNo = "R1", Name = "Shams Zia" };
        }

        public override List<Student> List(SearchInput searchInput)
        {
            return new List<Student> { new Student { }, new Student { } };
        }

        public string GetName(string key)
        {
            return "Arshad";
        }
    }
}
