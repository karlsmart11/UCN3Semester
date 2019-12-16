using System.Collections.Generic;
using Model;

namespace Interface
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        void ModifyCategory(Category category);
    }
}
