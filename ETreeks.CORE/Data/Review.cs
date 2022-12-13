using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Review
    {
        public decimal Id { get; set; }
        public decimal? review { get; set; }
        public decimal RESERVATION_ID { get; set; }
    }
}
