using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : Controller
    {
        private readonly IService<Trainer> _trainerService;
        public TrainerController(IService<Trainer> trainerService)
        {
            _trainerService = trainerService;
        }
        [HttpPost]
        public bool CreateCategory(Trainer trainer)
        {
          return _trainerService.Create(trainer);
        }
        [HttpPut]        
        public bool UpdateCategory(Trainer trainer)
        {
            return _trainerService.Update(trainer);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return _trainerService.Delete(id);
        }
        [HttpGet]
        public List<Trainer> GetAll() { return _trainerService.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public Trainer GetCategoryById(int id)
        {
            return _trainerService.GetById(id);
        }
    }
}
