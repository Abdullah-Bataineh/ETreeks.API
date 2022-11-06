using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETreeks.INFRA.Repository
{
    public class Mythread
    {
        private readonly IDbContext _dbContext;
        public Mythread(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public void TimerVerfiyCode()
        {


            Thread.Sleep(30000);
            var p = new DynamicParameters();
            p.Add("L_ID", Class1.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.DELETEVERIFYCODE", p, commandType: CommandType.StoredProcedure);


        }

    }
    public class LoginRepository : IRepository<Login>,IVerfiyAccountRepository
    {
        private readonly IDbContext _dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  int Create(Login login)
        {
            int result;
            int login_id;
            Random VerfiyCode = new Random();
            int _VerfiyCode = VerfiyCode.Next(1000, 9999);
            var p = new DynamicParameters();
            p.Add("EMAILLOGIN", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASSWORDLOGIN", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("CODE", _VerfiyCode, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ROLEID", login.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERID", login.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("LOGIN_ID", dbType: DbType.Int32, direction: ParameterDirection.Output); _dbContext.Connection.Execute("LOGIN_PACKAGE.CREATELOGIN", p, commandType: CommandType.StoredProcedure);
            login_id = p.Get<int>("LOGIN_ID");
            result = p.Get<int>("res");
            Class1.id = login_id;
            Mythread obj = new Mythread(_dbContext);
            Thread thread = new Thread(new ThreadStart(obj.TimerVerfiyCode));
            thread.Start();
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
            p.Add("CODE", login.Verify_Code, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("ROLEID", login.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("USERID", login.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("res", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.UPDATELOGIN", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("res");
            return result;
        }

        public int Verfiy(int code)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("L_ID", Class1.id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_CODE", code, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.CONFIRMVERIFYCODE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }
    }
}
