using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerCourseController : ControllerBase
    {
        private readonly IService<TrainerCourse> _trainerCourseService;
        public TrainerCourseController(IService<TrainerCourse> trainerCourseService)
        {
            _trainerCourseService = trainerCourseService;
        }
        [HttpPost]
        public bool CreateTrainerCourse(TrainerCourse trainerCourse)
        {
            return _trainerCourseService.Create(trainerCourse);
        }
        [HttpPut]
        public bool UpdateTrainerCourse(TrainerCourse trainerCourse)
        {
            return _trainerCourseService.Update(trainerCourse);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteTrainerCourse(int id)
        {
            return _trainerCourseService.Delete(id);
        }
        [HttpGet]
        public List<TrainerCourse> GetAll() { return _trainerCourseService.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public TrainerCourse GetCategoryById(int id)
        {
            return _trainerCourseService.GetById(id);
        }
    }
}
