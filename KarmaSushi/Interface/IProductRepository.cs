using System.Collections.Generic;
using Model;

namespace Interface
{
    public interface IProductRepository
    {
        Product GetProductByName(string name);
      /*  Product GetProductByPrice(double price);
        Product GetProductByCategory(Category category); */
        Product GetProductById(string id);
        List<Product> GetAllProducts();
        void ModifyProduct(Product product);
    }
}
