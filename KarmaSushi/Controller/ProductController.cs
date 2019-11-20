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
            IProduct instance = new ProductRepository();
            return instance.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            IProduct instance = new ProductRepository();
            return instance.GetProductByName(name);
        }

        /*
        public Product GetProductByPrice(double price)
        {
            IProduct instance = new ProductRepository();
            return instance.GetProductByPrice(price);
        }

        public Product GetProductByCategory(Category category)
        {
            IProduct instance = new ProductRepository();
            return instance.GetProductByCategory(category);
        }
        */
        public List<Product> GetAllProducts ()
        {
            IProduct instance = new ProductRepository();
            return instance.GetAllProducts();
        }



        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}