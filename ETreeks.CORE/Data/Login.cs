using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Login
    {
        
        public decimal Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Verify_Code { get; set; }
        public decimal? Role_Id { get; set; }
        public decimal? User_Id { get; set; }

       public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
