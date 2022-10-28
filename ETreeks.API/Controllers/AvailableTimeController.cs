using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableTimeController : Controller
    {
        private readonly IService<AvailableTime> _trainerService;
        private readonly IAvailableTimeService _trainerService2;
        public AvailableTimeController(IService<AvailableTime> trainerService, IAvailableTimeService trainerService2)
        {
            _trainerService = trainerService;
            _trainerService2 = trainerService2;
        }
        [HttpPost]
        public bool CreateCategory(AvailableTime availableTime)
        {
          return _trainerService.Create(availableTime);
        }
        [HttpPut]        
        public bool UpdateCategory(AvailableTime availableTime)
        {
            return _trainerService.Update(availableTime);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return _trainerService.Delete(id);
        }
        [HttpGet]
        public List<AvailableTime> GetAll() 
        {
            return _trainerService.GetAll();
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public AvailableTime GetCategoryById(int id)
        {
            return _trainerService.GetById(id);
        }

        [HttpGet]
        [Route("GetByTrainer/{id}")]
        public AvailableTime GetCategoryByTrainer(int id)
        {
            return _trainerService2.GetByTrainer(id);
        }
    }
}
