using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface ICourseService
    {
        public List<Course> GetByCatId(int cat_id);
        public List<CourseWithCategory> GetCourseWithCategory();
        public List<Course> Search(string c_name);
        public List<COURSEINCATEGORY> GetCourseinCategory();
    }
}
