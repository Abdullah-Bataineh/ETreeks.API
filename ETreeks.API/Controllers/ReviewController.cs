using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _Service;
        public ReviewController(IReviewService Service)
        {

            _Service=Service;
        }

        [HttpGet]
        [Route("GetREVIEWBYRESERVATION/{r_id}")]
        public Review GetReviewByReservation(int r_id)
        {
            return _Service.GetReviewByReservation(r_id);
        }
        [HttpPost]
        [Route("createreview")]
        public void createReview(Review review)
        {
            _Service.createReview(review);
    }
    }
}
