using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.DTO
{
    public class TistimonialWithUserName
    {
        public decimal Id { get; set; }
        public string Text { get; set; }
        public decimal? Status { get; set; }
        public decimal? User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Image { get; set; }

       


    }
}
