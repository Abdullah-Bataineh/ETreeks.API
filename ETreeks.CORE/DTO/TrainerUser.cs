using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.DTO
{
    public class TrainerUser
    {
        public decimal Id { get; set; }
        public string Certificate { get; set; }
        public string Location { get; set; }
        public decimal? Status { get; set; }
        public string Cv { get; set; }
        public decimal? Cat_Id { get; set; }
        public decimal? User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string Image { get; set; }

    }
}
