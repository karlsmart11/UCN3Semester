using System;
using System.Collections.Generic;
using Interface;
using Model;
using SQLRepository;

namespace Controller
{
    public class CategoryController : IDisposable
    {
        public Category GetCategoryById(int id)
        {
            ICategoryRepository instance = new CategoryRepository();
            return instance.GetCategoryById(id);
        }

        public List<Category> GetAllCategories()
        {
            ICategoryRepository instance = new CategoryRepository();
            return instance.GetAllCategories();
        }


        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
