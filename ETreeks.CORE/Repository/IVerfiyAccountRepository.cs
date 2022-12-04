using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface IVerfiyAccountRepository
    {
        int Verfiy(int code, int id);
    }
}
