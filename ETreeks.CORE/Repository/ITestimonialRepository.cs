using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface ITestimonialRepository
    {
        List<TistimonialWithUserName> GetAllTistimonialWithUserName();
        public List<TestimonialGuest> GetTestimonialGuests();
        public void CreateTestimonialguest(TestimonialGuest testimonial);
        public void UpdateStatus(int id, int status);
    }
}
