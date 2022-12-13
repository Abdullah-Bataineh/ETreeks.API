using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using MimeKit;
using MailKit.Net.Smtp;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IService<Login> _service;
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService, IService<Login> service)
        {

            _loginService = loginService;
            _service = service;
        }
        [HttpPost]
        [Route("SendWhatsapp/{user_id}")]
        public async Task<HttpResponseMessage> SendWhatspp(int user_id)
        {
            List<string> detalis = new List<string>();
            detalis = _loginService.GetPhoneNumber(user_id);
            string phonenumber = detalis[0];
            string _phonenumber = phonenumber.Substring(0);
            string v_code=detalis[1];
            
            var my_jsondata = new
            {
                token = "cr6gaocbnwc5u4er",
                to = _phonenumber,
                body = $"Dear Etreeks User,\r\nWe received a request to Register your Account at Etreeks\r\nYour  verification code is:\r\n*{v_code}*\r\nSincerely yours,\r\nThe Etreeks Accounts team"
            };
            using (var client = new HttpClient())
                

                using (var request = new HttpRequestMessage(HttpMethod.Post, $" https://api.ultramsg.com/instance26226/messages/chat?token={my_jsondata.token}&to={my_jsondata.to}&body={my_jsondata.body}"))
            {
                var json = JsonConvert.SerializeObject(my_jsondata);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;
                    using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        return response;
                    }
                }

            }



        }

        [HttpPost]
        [Route("SendEmail/{login_id}")]
        public void SendEmail(int login_id)
        {

           var login= _service.GetById(login_id);
            MimeMessage mail = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress("ETreeks", "etrreks123@gmail.com");
            MailboxAddress emailTo = new MailboxAddress("Email verification code:" + login.Verify_Code, login.Email);
            BodyBuilder bodyBuilder = new BodyBuilder();
            mail.From.Add(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = "Email verification code:" + login.Verify_Code;
            bodyBuilder.HtmlBody = "<td>        <div style='border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px' align='center' class='m_-9056096535776185231mdv2rw'>\r\n        <img src='https://i.postimg.cc/2SJbh5Gz/Green-Modern-Education-Online-Course-Logo-2.png' width ='170' height='110' aria-hidden='true' style='margin-bottom:16px' alt='Google' class='CToWUd' data-bit='iit'>        <div style='font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word'>            <div style='font-size:24px'>Verify The Account </div>       </div>        <div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left'>            ETreeks verfiy a account the email             <a style='font-weight:bold'>" + login.Email + "</a> . <br><br>             Use this code to verfiy email: <br>            <div style='text-align:center;font-size:36px;margin-top:20px;line-height:44px'>" + login.Verify_Code + "</div> <br>            This code will expire in 2 minutes. <br> <br>         </div>        </div>\r\n            <div style='text-align:left'><div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center'>               <div>\r\n                    You received this email to let you know about important changes to your ETreeks Account and services.</div><div style='direction:ltr'>© 2022 ETreeks LLC,                </div></div></div></td>";
            mail.Body = bodyBuilder.ToMessageBody();
           
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("imap.gmail.com", 465, true);
            smtpClient.Authenticate("etrreks123@gmail.com", "waozndqxwxgzvirc");
            smtpClient.Send(mail);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();

        }

        [HttpPut]
        [Route("DeleteCode/{id}")]
        public void DELETEVERIFYCODE(int id)
        {
            _loginService.DELETEVERIFYCODE(id);
        }


        [HttpPost]
        [Route("Create")]
        public int CreateLogIn(Login login)
        {
            return _loginService.CreateLogIn(login);
        }

        [HttpGet]
        [Route("GetByUserId/{userid}")]
        public Login GetByUserId(int userid)
        {
            return _loginService.GetByUserId(userid);

        }
        [HttpGet]
        [Route("GetIdByEmail/{email}")]
        public int GetIdByEmail(string email)
        {
            return _loginService.GetIdByEmail(email);
        }
    }
}
