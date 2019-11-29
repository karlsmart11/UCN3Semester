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
        private readonly IProductRepository _productRepository = null;
        public ProductController(){ }

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public Product GetProductById(string id)
        {
            IProductRepository instance = _productRepository ?? new ProductRepository();
            return instance.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            IProductRepository instance = _productRepository ?? new ProductRepository();
            return instance.GetProductByName(name);
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
            IProductRepository instance = _productRepository ?? new ProductRepository();
            return instance.GetAllProducts();
        }



        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}