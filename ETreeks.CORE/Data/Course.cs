using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Course
    {
        public Course()
        {
            TrainerCourses = new HashSet<TrainerCourse>();
        }

        public decimal Id { get; set; }
        public string COURSE_NAME { get; set; }
        public string Description { get; set; }
        public decimal? Cat_Id { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<TrainerCourse> TrainerCourses { get; set; }
    }
}
