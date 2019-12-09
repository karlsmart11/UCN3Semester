using System.Collections.Generic;
using KarmaWeb.OrderServiceRef;
using Category = KarmaWeb.ProductServiceRef.Category;
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
        public List<Category> Categories { get; set; }
}
}