﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class TrainerCourse
    {
        public TrainerCourse()
        {
            Reservations = new HashSet<Reservation>();
        }

        public decimal Id { get; set; }
        public decimal? CourseId { get; set; }
        public decimal? TrainerId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
