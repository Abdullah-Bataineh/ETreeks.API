using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Reservation
    {
        public decimal Id { get; set; }
        public decimal? avaliable_time_id { get; set; }
        public decimal? Status { get; set; }
        public decimal? User_Id { get; set; }
        public decimal? Trainer_Course_Id { get; set; }

        public virtual TrainerCourse TrainerCourse { get; set; }
        public virtual User User { get; set; }
    }
}
