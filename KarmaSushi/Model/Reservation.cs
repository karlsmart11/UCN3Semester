using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceKarma.Model
{
    public class Reservation
    {
        public DateTime Time { get; set; }
        public Table Table { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
    }
}