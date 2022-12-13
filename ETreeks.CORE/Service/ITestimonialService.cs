using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface ITestimonialService
    {
        public List<TistimonialWithUserName> GetAllTistimonialWithUserName();
        public List<TestimonialGuest> GetTestimonialGuests();
        public void CreateTestimonialguest(TestimonialGuest testimonial);
    }
}
