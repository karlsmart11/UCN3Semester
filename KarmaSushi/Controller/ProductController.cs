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
        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        IProduct _productRepository = null;

        public Product GetProductById(string id)
        {
            return _productRepository.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            return _productRepository.GetProductByName(name);
        }

        /*
        public Product GetProductByPrice(double price)
        {
            return _productRepository.GetProductByPrice(price);
        }

        public Product GetProductByCategory(Category category)
        {
            return _productRepository.GetProductByCategory(category);
        }
        */
        public List<Product> GetAllProducts ()
        {
            return _productRepository.GetAllProducts();
        }



        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}