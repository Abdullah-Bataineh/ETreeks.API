using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.DTO
{
    public class trainerEmail
    {
        public decimal Id { get; set; }
        public string Certificate { get; set; }
        public string Location { get; set; }
        public decimal? Status { get; set; }
        public string Cv { get; set; }
        public decimal? Cat_Id { get; set; }
        public decimal? User_Id { get; set; }
        public string Email { get; set; }
    }
}
