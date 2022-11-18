using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetByCatId(int cat_id);
    }
}
