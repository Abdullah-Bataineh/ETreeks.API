using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.CORE.Repository
{
    public interface ILoginRepository
    {
       
        public List<string> GetPhoneNumber(int id);
    }
}
