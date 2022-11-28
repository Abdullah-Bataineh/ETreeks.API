using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.DTO
{
    public class UserLogin
    {
        
        public decimal Id { get; set; }

        public decimal? User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Phone_Number { get; set; }
        public DateTime? Birth_Date { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Verify_Code { get; set; }
        public decimal? Role_Id { get; set; }
        
    }
}
