using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category> _categoryService;
        public CategoryController(IService<Category> categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public bool CreateCategory(Category category)
        {
          return _categoryService.Create(category);
        }
        [HttpPut]
        public bool UpdateCategory(Category category)
        {
            return _categoryService.Update(category);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return _categoryService.Delete(id);
        }
        [HttpGet]
        public List<Category> GetAll() { return _categoryService.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoryService.GetById(id);
        }
    }
}
