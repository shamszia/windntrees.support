using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Controls.Navs
{
    [DataContract]
    public class ItemAttribute
    {
        [DataMember]
        private String name;

        [DataMember]
        private String value;

        public ItemAttribute()
        {

        }

        public ItemAttribute(String name, String value)
        {
            this.name = name;
            this.value = value;
        }

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getValue()
        {
            return value;
        }

        public void setValue(String value)
        {
            this.value = value;
        }
    }
}
