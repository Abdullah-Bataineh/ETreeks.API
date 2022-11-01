using ETreeks.CORE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETreeks.CORE.Repository
{
    public interface IJWTRepository
    {
        Login Auth(Login login);

    }
}

