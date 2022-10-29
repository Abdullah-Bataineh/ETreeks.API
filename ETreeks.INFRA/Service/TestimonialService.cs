using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.INFRA.Service
{//abdullah
    public class TestimonialService : IService<Testimonial>
    {
        private readonly IRepository<Testimonial> _testimonialrepository;

        public TestimonialService(IRepository<Testimonial> testimonialrepository)
        {
            _testimonialrepository= testimonialrepository;
        }
        public bool Create(Testimonial testimonial)
        {
            int result;
            result = _testimonialrepository.Create(testimonial);
            if (result == 1)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            int result;
            result = _testimonialrepository.Delete(id);
            if (result == 1)
                return true;
            else
                return false;
        }

        public List<Testimonial> GetAll()
        {
           return _testimonialrepository.GetAll();
        }

        public Testimonial GetById(int id)
        {
            return _testimonialrepository.GetById(id);
        }

        public bool Update(Testimonial testimonial)
        {
            int result;
            result = _testimonialrepository.Update(testimonial);
            if (result == 1)
                return true;
            else
                return false;
        }
    }
}
