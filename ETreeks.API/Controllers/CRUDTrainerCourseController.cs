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
    public class CRUDTrainerCourseController : CRUDController<TrainerCourse>
    {
        public CRUDTrainerCourseController(IService<TrainerCourse> trainerCourseService)
        : base(trainerCourseService)
        {

        }
    }
}
