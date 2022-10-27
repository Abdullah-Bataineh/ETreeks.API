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
        public string VerifyCode { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? UserId { get; set; }

       public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
