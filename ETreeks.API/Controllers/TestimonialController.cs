using ETreeks.CORE.DTO;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {

            _testimonialService = testimonialService;
        }
        [HttpGet]
        [Route("getall")]
        public List<TistimonialWithUserName> GetAllTistimonialWithUserName()
        {
            return _testimonialService.GetAllTistimonialWithUserName();
        }

    }
}
