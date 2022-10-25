using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Testimonial
    {
        public decimal Id { get; set; }
        public string Text { get; set; }
        public decimal? Status { get; set; }
        public decimal? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
