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
       
        private readonly IAvailableTimeService _availableService;
        public AvailableTimeController(IAvailableTimeService availableService)
        {
          _availableService = availableService;
            
        }
        
        [HttpGet]
        [Route("GetByTrainer/{id}")]
        public List<AvailableTime> GetByTrainer(int id)
        {
            return _availableService.GetByTrainer(id);
        }
        [HttpPut]
        [Route("update/{id}/{st}")]
        public void updateStatusbyID(int id, int st)
        {
            _availableService.updateStatusbyID(id, st);
        }
        [HttpGet]
        [Route("GetByTrainerid/{t_id}")]
        public List<AvailableTime> GetByTrainerid(int t_id)
        {
            return _availableService.GetByTrainerid(t_id);
        }
    }
}
