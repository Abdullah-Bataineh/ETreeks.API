using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
            Trainers = new HashSet<Trainer>();
        }

        public decimal Id { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string IMAGE { get; set; }
        public string DESCRIPTION { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
