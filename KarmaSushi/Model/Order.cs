using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceKarma.Model
{
    public class Order
    {
        public DateTime Time { get; set; }
        public Customer Customer { get; set; }
        public Table Table { get; set; }
        public OrderLine OrderLine { get; set; }
    }
}