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
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool Create(Category category)
        {
            int result;
            result = _categoryRepository.Create(category);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _categoryRepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<Category> GetAll()
        {
           return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
           return _categoryRepository.GetById(id);
        }

        public bool Update(Category category)
        {
            int result;
            result = _categoryRepository.Update(category);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
