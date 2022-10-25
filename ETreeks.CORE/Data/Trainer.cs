using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Trainer
    {
        public Trainer()
        {
            AvailableTimes = new HashSet<AvailableTime>();
            TrainerCourses = new HashSet<TrainerCourse>();
        }

        public decimal Id { get; set; }
        public string Certificate { get; set; }
        public string Location { get; set; }
        public decimal? Status { get; set; }
        public string Cv { get; set; }
        public decimal? CatId { get; set; }
        public decimal? UserId { get; set; }

        public virtual Category Cat { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<AvailableTime> AvailableTimes { get; set; }
        public virtual ICollection<TrainerCourse> TrainerCourses { get; set; }
    }
}
