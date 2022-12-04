using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerCourseController : ControllerBase
    {
        private readonly ITrainerCourseService _trainerService;
        public TrainerCourseController(ITrainerCourseService trainerService)
        {

            _trainerService = trainerService;
        }

        [HttpGet]
        [Route("GetTrainerCourse/{id}")]
        public List<Course> GetTrainerCourseByUserId(int id)
        {
            return _trainerService.GetTrainerCourseByUserId(id);
        }
    }
}
