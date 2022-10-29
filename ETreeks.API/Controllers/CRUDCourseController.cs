using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Mvc;
//  new CRUDController<Course>(CourceService);
namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDCourseController : CRUDController<Course>
    {
        public CRUDCourseController(IService<Course> courseService)
        : base(courseService)
        {

        }
    }


}
