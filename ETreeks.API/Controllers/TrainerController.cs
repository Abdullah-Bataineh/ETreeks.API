using ETreeks.CORE.DTO;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }
        [Route("CreateTrainer")]
        [HttpPost]
        public List<KeyValuePair<string,int>> CreateTrainer(TrainerLogin trainerlogin)
        {

            return _trainerService.CreateTrainer(trainerlogin);
        }
    }
}
