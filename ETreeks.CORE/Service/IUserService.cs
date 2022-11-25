using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Service
{
    public interface IUserService
    {
        public List<User> Search(string c_name);
        public List<KeyValuePair<string, int>> CreateUser(UserLogin userlogin);
    }
}
