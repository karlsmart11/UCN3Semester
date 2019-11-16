using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceKarma.Model
{   [DataContract]
    public class Table
    {   [DataMember]
        public string Name { get; set; }
    }
}