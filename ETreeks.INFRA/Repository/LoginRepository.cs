using Dapper;
using ETreeks.CORE.Common;
using ETreeks.CORE.Data;
using ETreeks.CORE.Repository;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Org.BouncyCastle.Asn1.Crmf;


namespace ETreeks.INFRA.Repository
{    public static class detalis_login
    {
        public static decimal? id;
    }
    
    
    public class LoginRepository : IRepository<Login>,IVerfiyAccountRepository,ILoginRepository
    {
        private readonly IDbContext _dbContext;
        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public  int CreateLogIn(Login login)
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
            p.Add("LOGIN_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.CREATELOGIN", p, commandType: CommandType.StoredProcedure);
            login_id = p.Get<int>("LOGIN_ID");
            result = login_id;


                         



            //detalis_login.id = login_id;
            //Mythread obj = new Mythread(_dbContext);
            //Thread thread = new Thread(new ThreadStart(obj.TimerVerfiyCode));
            //thread.Start();

            return result;
            
            
        }




        public void DELETEVERIFYCODE(int id)
        {

            var p = new DynamicParameters();
            p.Add("L_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.DELETEVERIFYCODE", p, commandType: CommandType.StoredProcedure);

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

        public Login GetByUserId(int userid)
        {
            var p = new DynamicParameters();
            p.Add("USERINID", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Login> result = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GETLOGINBYUSERID", p, commandType: CommandType.StoredProcedure);
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

        public int Verfiy(int code,int id)
        {
            int result;
            var p = new DynamicParameters();
            p.Add("L_ID", id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("V_CODE", code, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("RES", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.CONFIRMVERIFYCODE", p, commandType: CommandType.StoredProcedure);
            result = p.Get<int>("RES");
            return result;
        }

       

        public List<string> GetPhoneNumber(int id)
        {
            string d="";
            int y=0;
            List<string> result = new List<string>();
            var p = new DynamicParameters();
            p.Add("L_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
           p.Add("PH_NUM",d, dbType: DbType.String, direction: ParameterDirection.Output);
           p.Add("V_CODE",y, dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.GETPHONENUMBER", p, commandType: CommandType.StoredProcedure);
            result.Add(p.Get<string>("PH_NUM"));
            result.Add(p.Get<int>("V_CODE").ToString());
            return result;
        }

        public int Create(Login t)
        {
            throw new NotImplementedException();
        }
    }
}
