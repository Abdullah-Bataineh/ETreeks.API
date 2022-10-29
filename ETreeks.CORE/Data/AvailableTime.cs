using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class AvailableTime
    {
        public decimal Id { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public decimal? Trainer_Id { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
