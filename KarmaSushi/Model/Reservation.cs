using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{   [DataContract]
    public class Reservation
    {   
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public Table Table { get; set; }
        [DataMember]
        public Employee Employee { get; set; }
        [DataMember]
        public Customer Customer { get; set; }
    }
}