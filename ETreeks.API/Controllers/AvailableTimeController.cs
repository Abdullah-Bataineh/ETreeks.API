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
       
        private readonly IAvailableTimeService _trainerService;
        public AvailableTimeController(IAvailableTimeService trainerService)
        {
           
            _trainerService = trainerService;
        }
        
        [HttpGet]
        [Route("GetByTrainer/{id}")]
        public AvailableTime GetCategoryByTrainer(int id)
        {
            return _trainerService.GetByTrainer(id);
        }
    }
}
