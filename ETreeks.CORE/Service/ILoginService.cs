using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.CORE.Service
{
    public interface ILoginService
    {
        public string GetPhoneNumber(int id);
    }
}
