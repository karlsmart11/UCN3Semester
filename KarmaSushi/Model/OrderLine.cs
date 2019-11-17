using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceKarma.Model
{   
    [DataContract]
    public class OrderLine
    {   [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public double Price { get; set; }
    }
}