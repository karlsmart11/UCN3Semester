using System;
using System.Collections.Generic;
using System.ServiceModel;
using Controller;
using Model;
using ServiceContract;

namespace Implementation
{
    public class CategoryManager : ICategoryService
    {
        public Category GetCategoryById(int id)
        {
            try
            {
                using (var instance = new CategoryController())
                {
                    return instance.GetCategoryById(id);
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

        public List<Category> GetAllCategories()
        {
            try
            {
                using (var instance = new CategoryController())
                {
                    return instance.GetAllCategories();
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
