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
    
    public class Mythread
    {
        private readonly IDbContext _dbContext;
        public Mythread(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public void TimerVerfiyCode()
        {


            Thread.Sleep(100000);
            var p = new DynamicParameters();
            p.Add("L_ID", detalis_login.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.DELETEVERIFYCODE", p, commandType: CommandType.StoredProcedure);


        }

    }
    public class LoginRepository : IRepository<Login>,IVerfiyAccountRepository,ILoginRepository
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
            p.Add("LOGIN_ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            _dbContext.Connection.Execute("LOGIN_PACKAGE.CREATELOGIN", p, commandType: CommandType.StoredProcedure);
            login_id = p.Get<int>("LOGIN_ID");
            result = p.Get<int>("res");
            MimeMessage mail = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress("ETreeks", "eetreeks@gmail.com");
            MailboxAddress emailTo = new MailboxAddress("Email verification code:"+ _VerfiyCode, login.Email);
            BodyBuilder bodyBuilder = new BodyBuilder();
            mail.From.Add(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = "Email verification code:" + _VerfiyCode;
            bodyBuilder.HtmlBody = "<td>        <div style='border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px' align='center' class='m_-9056096535776185231mdv2rw'>\r\n        <img src='https://iili.io/yqtacP.png' width='170' height='110' aria-hidden='true' style='margin-bottom:16px' alt='Google' class='CToWUd' data-bit='iit'>        <div style='font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word'>            <div style='font-size:24px'>Verify The Account </div>       </div>        <div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left'>            ETreeks verfiy a account the email             <a style='font-weight:bold'>" + login.Email+"</a> . <br><br>             Use this code to verfiy email: <br>            <div style='text-align:center;font-size:36px;margin-top:20px;line-height:44px'>"+_VerfiyCode+"</div> <br>            This code will expire in 2 minutes. <br> <br>         </div>        </div>\r\n            <div style='text-align:left'><div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center'>               <div>\r\n                    You received this email to let you know about important changes to your ETreeks Account and services.</div><div style='direction:ltr'>© 2022 ETreeks LLC,                </div></div></div></td>";
            mail.Body = bodyBuilder.ToMessageBody();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 465,true); 
            smtpClient.Authenticate("eetreeks@gmail.com", "zbrmoqepihukzszv");
            smtpClient.Send(mail);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();
            detalis_login.id = login_id;
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
            p.Add("L_ID", detalis_login.id, dbType: DbType.String, direction: ParameterDirection.Input);
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
    }
}
