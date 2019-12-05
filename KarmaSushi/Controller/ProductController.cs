using SQLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interface;
using Model;

namespace Controller
{
    public class ProductController :  IDisposable
    {
        public Product GetProductById(string id)
        {
            IProductRepository instance = new ProductRepository();
            return instance.GetProductById(id);
        }
        public Product GetProductByName(string name)
        {
            IProductRepository instance = new ProductRepository();
            return instance.GetProductByName(name);
        }
        public List<Product> GetAllProducts ()
        {
            IProductRepository instance = new ProductRepository();
            return instance.GetAllProducts();
        }
        public void ModifyProduct(Product product)
        {
            IProductRepository instance = new ProductRepository();
            instance.ModifyProduct(product);
        }


        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}