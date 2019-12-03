using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KarmaWeb.OrderServiceRef;
using KarmaWeb.ProductServiceRef;
using Product = KarmaWeb.ProductServiceRef.Product;

namespace KarmaWeb.Models
{
    public class OrderViewModel
    {
        public List<Product> Products { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public string  OrderComment { get; set; }
        public double TotSum { get; set; }
        public double Sum { get; set; }
        public Order CurrentOrder { get; set; }
        public Product Product { get; set; }
    }
}