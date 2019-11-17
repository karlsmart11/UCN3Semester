using ServiceKarma.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Contract
{
    public interface IProduct
    {
        Product GetProductByName(string name);
        Product GetProductByPrice(double price);
        Product GetProductByCategory(Category category);
    }
}
