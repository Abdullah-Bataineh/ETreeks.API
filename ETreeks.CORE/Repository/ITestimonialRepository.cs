using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface ITestimonialRepository
    {
        List<TistimonialWithUserName> GetAllTistimonialWithUserName();
    }
}
