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
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string VerifyCode { get; set; }
        public decimal? CatId { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<TrainerCourse> TrainerCourses { get; set; }
    }
}
