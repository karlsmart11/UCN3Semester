using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IProduct
    {
        public Product GetProductByName(string name);
        public Product GetProductByPrice(double price);
        public Product GetProductByCategory(Category category);
    }
}
