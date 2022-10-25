using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class AvailableTime
    {
        public decimal Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TrainerId { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
