using System;
using System.Collections.Generic;

#nullable disable

namespace ETreeks.CORE.Data
{
    public partial class Role
    {
        public Role()
        {
            Logins = new HashSet<Login>();
        }

        public decimal Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
