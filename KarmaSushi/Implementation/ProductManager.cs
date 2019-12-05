using Controller;
using Model;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    public class ProductManager : IProductServices
    {
        public Product GetProductById(string id)
        {
            try
            {
                using (var instance = new ProductController())
                {
                    return instance.GetProductById(id);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public Product GetProductByName(string name)
        {
            try
            {
                using (var instance = new ProductController())
                {
                    return instance.GetProductByName(name);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public List<Product> GetAllProducts()
        {
            try
            {
                using (var instance = new ProductController())
                {
                    return instance.GetAllProducts();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public void ModifyProduct(Product product)
        {
            try
            {
                using (var instance = new ProductController())
                {
                    instance.ModifyProduct(product);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error()
                {
                    CodigoError = "10001",
                    Mensaje = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }
    }
}
