using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ETreeks.INFRA.Repository
{
    public class LoginRepository : IRepository<Login>
    {
        private readonly IDbContext _dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Login login)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("EMAILLOGIN", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORDLOGIN", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CODE", login.VerifyCode, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLEID", login.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERID", login.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.CREATELOGIN", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public int Delete(int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("LOGINID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.DELETELOGIN", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        List<Login> IRepository<Login>.GetAll()
        {
            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GETALLLOGIN", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Login GetById(int id)
        {
            var p = new DynamicParameters();
            p.Add("LOGINID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GETLOGINBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(Login login)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("LOGINID", login.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("EMAILLOGIN", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORDLOGIN", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CODE", login.VerifyCode, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROLEID", login.RoleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERID", login.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.UPDATELOGIN", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }
    }
}
