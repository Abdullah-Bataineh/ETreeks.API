using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Login
    {
        public Login()
        {
            Roles = new HashSet<Role>();
            Users = new HashSet<User>();
        }
        public decimal Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string VerifyCode { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? UserId { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
