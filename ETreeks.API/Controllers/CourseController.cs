using ETreeks.CORE.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using ETreeks.CORE.Service;
using System.Collections.Generic;
using ETreeks.CORE.DTO;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
           _courseService = courseService;
        }
        [Route("uploadImage")]
        [HttpPost]
        public Course UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(@"C:\ETreeks\src\assets\images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Course item = new Course();
            item.IMAGE = fileName;
            return item;

        }
        [HttpGet]
        [Route("getbycatid/{cat_id}")]
        public List<Course> GetByCatId(int cat_id)
        {
            return _courseService.GetByCatId(cat_id);
        }
        [HttpGet]
        [Route("getcoursewithcategory")]
        public List<CourseWithCategory> GetCourseWithCategory()
        {
            return _courseService.GetCourseWithCategory();
        }


        [Route("Search/{c_name}")]
        [HttpGet]
        public List<Course> Search(string c_name)
        {
            return _courseService.Search(c_name);
        }
        [Route("courseincategory")]
        [HttpGet]
        public List<COURSEINCATEGORY> GetCourseinCategory()
        {
            return _courseService.GetCourseinCategory();
        }
    }
}
