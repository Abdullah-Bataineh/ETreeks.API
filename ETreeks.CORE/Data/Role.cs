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
        public string Role_Name { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}
