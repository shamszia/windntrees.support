using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Core.Repositories
{
    public class GenericList
    {
        public string ItemText { get; set; }
        public long ItemValue { get; set; }
    }

    public class GenericListString
    {
        public string ItemText { get; set; }
        public string ItemValue { get; set; }
    }

    public class GenericListImage
    {
        public string ItemText { get; set; }
        public string ItemValue { get; set; }
        public string ImageFile { get; set; }
    }
}
