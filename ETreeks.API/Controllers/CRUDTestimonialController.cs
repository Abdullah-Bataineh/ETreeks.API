using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDTestimonialController : CRUDController<Testimonial>
    {
        public CRUDTestimonialController(IService<Testimonial> testimonialservice) : base(testimonialservice)
        {
        }
    }
}
