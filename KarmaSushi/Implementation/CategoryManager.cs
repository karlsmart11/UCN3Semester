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
                throw new FaultException<Error>(new Error
                {
                    ErrorCode = "10001",
                    Message = ex.Message,
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
                throw new FaultException<Error>(new Error
                {
                    ErrorCode = "10001",
                    Message = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }

        public void ModifyCategory(Category category)
        {
            try
            {
                using (var instance = new CategoryController())
                {
                    instance.ModifyCategory(category);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException<Error>(new Error
                {
                    ErrorCode = "10001",
                    Message = ex.Message,
                    Description = "Exception managed by the administrator"
                });
            }
        }
    }
}
