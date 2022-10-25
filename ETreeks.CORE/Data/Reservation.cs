using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Reservation
    {
        public decimal Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Status { get; set; }
        public decimal? UserId { get; set; }
        public decimal? TrainerCourseId { get; set; }

        public virtual TrainerCourse TrainerCourse { get; set; }
        public virtual User User { get; set; }
    }
}
