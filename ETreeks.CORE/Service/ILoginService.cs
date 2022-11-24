using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.CORE.Service
{
    public interface ILoginService
    {
        public List<string> GetPhoneNumber(int id);
        public void DELETEVERIFYCODE(int id);
        public int CreateLogIn(Login login);
    }
}
