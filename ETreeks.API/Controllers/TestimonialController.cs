using ETreeks.CORE.Data;
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
        [Route("GetAllTistimonialUser")]
        public List<TistimonialWithUserName> GetAllTistimonialWithUserName()
        {
            return _testimonialService.GetAllTistimonialWithUserName();
        }
        [HttpGet]
        [Route("GetAllTistimonialguest")]
        public List<TestimonialGuest> GetTestimonialGuests()
        {
            return _testimonialService.GetTestimonialGuests();
        }
        [HttpPost]
        [Route("createTistimonialguest")]
        public void CreateTestimonialguest(TestimonialGuest testimonial)
        {
            _testimonialService.CreateTestimonialguest(testimonial);
        }
        [HttpPut]
        [Route("updatestatus/{id}/{status}")]
        public void UpdateStatus(int id, int status)
        {
            _testimonialService.UpdateStatus(id, status);
        }
    }
}
