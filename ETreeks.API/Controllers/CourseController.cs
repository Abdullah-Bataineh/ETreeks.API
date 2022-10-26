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
    public class CourseController : ControllerBase
    {
        private readonly IService<Course> _courseService;
        public CourseController(IService<Course> courseService)
        {
            _courseService = courseService;
        }
        [HttpPost]
        public bool CreateCourse(Course course)
        {
            return _courseService.Create(course);
        }
        [HttpPut]
        [Route("Update/{id}")]
        public bool UpdateCourse(Course course)
        {
            return _courseService.Update(course);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCourse(int id)
        {
            return _courseService.Delete(id);
        }
        [HttpGet]
        public List<Course> GetAll() { return _courseService.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public Course GetCategoryById(int id)
        {
            return _courseService.GetById(id);
        }
    }
}
