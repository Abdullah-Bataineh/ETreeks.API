﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ETreeks.CORE.Common
{
    public interface IDbContext
    {
        public DbConnection Connection { get; }
    }
}
