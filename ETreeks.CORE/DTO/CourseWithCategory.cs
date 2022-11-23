using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.DTO
{
    public class CourseWithCategory
    {
        public decimal id { get; set; }
        public decimal? Cat_Id { get; set; }
        public string COURSE_NAME { get; set; }
        public string Description { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string IMAGE { get; set; }
    }
}
