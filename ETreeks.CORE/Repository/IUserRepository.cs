using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface IUserRepository
    {
        public List<User> Search(string c_name);
        public List<KeyValuePair<string, int>> CreateUser(UserLogin userlogin);

        public void Updateuserlogin(UserLogin userlogin);
        public void ResendCode(int id);
    }
        
}
