using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : Controller
    {
        private readonly IService<About> _aboutService;
        public AboutController(IService<About> aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpPost]
        public bool CreateCategory(About about)
        {
          return _aboutService.Create(about);
        }
        [HttpPut]        
        public bool UpdateCategory(About about)
        {
            return _aboutService.Update(about);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return _aboutService.Delete(id);
        }
        [HttpGet]
        public List<About> GetAll() { return _aboutService.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public About GetCategoryById(int id)
        {
            return _aboutService.GetById(id);
        }
    }
}
