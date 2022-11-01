using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;

namespace ETreeks.INFRA.Repository
{
    public class JWTRepository : IJWTRepository
    {
        private readonly IDbContext _dbContext;

        public JWTRepository(IDbContext dBContext)
        {
            _dbContext = dBContext;
        }
        public Login Auth(Login login)
        {

            var p = new DynamicParameters();
            p.Add("email2", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
