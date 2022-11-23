using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface ITestimonialService
    {
        List<TistimonialWithUserName> GetAllTistimonialWithUserName();
    }
}
