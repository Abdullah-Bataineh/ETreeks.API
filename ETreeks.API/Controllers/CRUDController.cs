using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController<T> : Controller
    {
        private readonly IService<T> _aboutService;
        public CRUDController(IService<T> aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpPost]
        public bool CreateCategory(T itrm)
        {
          return _aboutService.Create(itrm);
        }
        [HttpPut]        
        public bool UpdateCategory(T itrm)
        {
            return _aboutService.Update(itrm);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return _aboutService.Delete(id);
        }
        [HttpGet]
        public List<T> GetAll() { return _aboutService.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public T GetCategoryById(int id)
        {
            return _aboutService.GetById(id);
        }
    }
}
