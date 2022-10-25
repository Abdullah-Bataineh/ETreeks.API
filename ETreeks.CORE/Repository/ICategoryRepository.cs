using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        int CreateCategory(Category category);
        int UpdateCategory(Category category);
        int DeleteCategory(int id);


    }
}
