using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.DTO
{
    public class search
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public decimal? Status { get; set; }
        public string COURSE_NAME { get; set; }
        public decimal? id { get; set; }

    }
}
