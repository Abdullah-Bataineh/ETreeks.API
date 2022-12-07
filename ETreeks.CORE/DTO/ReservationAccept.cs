using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.DTO
{
    public class ReservationAccept
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Image { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public string COURSE_NAME { get; set; }
        public decimal Id { get; set; }
        public decimal? avaliable_time_id { get; set; }

        public string Location { get; set; }

        public decimal? User_Id { get; set; }
        public decimal? Trainer_Course_Id { get; set; }
        public decimal LOGINID { get; set; }
        public decimal AVAILABLEID { get; set; }
        public decimal? STATUS { get; set; }
    }
}
