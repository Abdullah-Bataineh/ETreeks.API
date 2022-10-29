using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    
    [ApiController]
    public class CRUDController<T> : Controller
    {
        private readonly IService<T> _service;
        public CRUDController(IService<T> service)
        {
            _service = service;
        }
        [HttpPost]
        public bool CreateCategory(T itrm)
        {
          return _service.Create(itrm);
        }
        [HttpPut]        
        public bool UpdateCategory(T itrm)
        {
            return _service.Update(itrm);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return _service.Delete(id);
        }
        [HttpGet]
        public List<T> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public T GetCategoryById(int id)
        {
            return _service.GetById(id);
        }
    }
}
