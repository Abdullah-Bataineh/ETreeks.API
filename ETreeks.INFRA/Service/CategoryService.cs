using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{
    public class CategoryService : IService<Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool Create(Category category)
        {
            int result;
            result = _categoryRepository.CreateCategory(category);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _categoryRepository.DeleteCategory(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<Category> GetAll()
        {
           return _categoryRepository.GetAllCategories();
        }

        public Category GetById(int id)
        {
           return _categoryRepository.GetCategoryById(id);
        }

        public bool Update(Category category)
        {
            int result;
            result = _categoryRepository.UpdateCategory(category);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
