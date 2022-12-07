using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ETreeks.CORE.Data;

namespace ETreeks.CORE.Repository
{
    public interface ILoginRepository
    {
       
        public List<string> GetPhoneNumber(int id);
        public void DELETEVERIFYCODE(int id);

        public int CreateLogIn(Login login);

        public Login GetByUserId(int userid);

        public int GetIdByEmail(string email);

    }
}
