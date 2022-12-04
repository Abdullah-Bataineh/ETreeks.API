using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Service;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Collections.Generic;


namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;
        private readonly IService<Login> _service;

        public TrainerController(ITrainerService trainerService,IService<Login> service)
        {
            _trainerService = trainerService;
            _service = service;
        }
        [Route("CreateTrainer")]
        [HttpPost]
        public List<KeyValuePair<string,int>> CreateTrainer(TrainerLogin trainerlogin)
        {

            return _trainerService.CreateTrainer(trainerlogin);
        }
        [Route("getTrainer")]
        [HttpGet]
        public List<TrainerUser> GetTrainerUser()
        {
            return _trainerService.GetTrainerUser();
        }
        [HttpPost]
        [Route("SendEmail/{trainer_id}")]
        public void SendEmail(int trainer_id)
        {

            var login = _trainerService.getTrainerEmailbyId(trainer_id);
            MimeMessage mail = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress("ETreeks", "etrreks123@gmail.com");
            MailboxAddress emailTo = new MailboxAddress("Acceptancee Regester", login.Email);
            BodyBuilder bodyBuilder = new BodyBuilder();
            mail.From.Add(emailFrom);
            mail.To.Add(emailTo);
            if (login.Status == 1)
            {
                mail.Subject = "Acceptance Regester";
                bodyBuilder.HtmlBody = "<td>        <div style='border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px' align='center' class='m_-9056096535776185231mdv2rw'>\r\n        <img src='https://i.postimg.cc/2SJbh5Gz/Green-Modern-Education-Online-Course-Logo-2.png' width ='170' height='110' aria-hidden='true' style='margin-bottom:16px' alt='Google' class='CToWUd' data-bit='iit'>        <div style='font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word'>            <div style='font-size:24px'>Verify The Account </div>       </div>        <div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left'>            ETreeks verfiy a account the email             <a style='font-weight:bold'>" + login.Email + "</a> . <br><br>            <br>            <div style='text-align:center;font-size:36px;margin-top:20px;line-height:44px'> Your Register was accepted </div> <br>            <br> <br>         </div>        </div>\r\n            <div style='text-align:left'><div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center'>               <div>\r\n                    You received this email to let you know about important changes to your ETreeks Account and services.</div><div style='direction:ltr'>© 2022 ETreeks LLC,                </div></div></div></td>";
            }
            else
            {
                mail.Subject = "Acceptance Regester";
                bodyBuilder.HtmlBody = "<td>        <div style='border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px' align='center' class='m_-9056096535776185231mdv2rw'>\r\n        <img src='https://i.postimg.cc/2SJbh5Gz/Green-Modern-Education-Online-Course-Logo-2.png' width ='170' height='110' aria-hidden='true' style='margin-bottom:16px' alt='Google' class='CToWUd' data-bit='iit'>        <div style='font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word'>            <div style='font-size:24px'>Verify The Account </div>       </div>        <div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left'>            ETreeks verfiy a account the email             <a style='font-weight:bold'>" + login.Email + "</a> . <br><br>              <br>            <div style='text-align:center;font-size:36px;margin-top:20px;line-height:44px'>Your Register was Rejected</div> <br>             <br> <br>         </div>        </div>\r\n            <div style='text-align:left'><div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center'>               <div>\r\n                    You received this email to let you know about important changes to your ETreeks Account and services.</div><div style='direction:ltr'>© 2022 ETreeks LLC,                </div></div></div></td>";
            }
           
            mail.Body = bodyBuilder.ToMessageBody();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("imap.gmail.com", 465, true);
            smtpClient.Authenticate("etrreks123@gmail.com", "waozndqxwxgzvirc");
            smtpClient.Send(mail);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();
            
        }
        [Route("searchTrainer/{name}")]
        [HttpGet]
        public List<TrainerUser> searchTrainer(string name)
        {
            return _trainerService.searchTrainer(name);
        }
        [Route("getTrainerUser/{id}")]
        [HttpGet]
        public List<TrainerUser> GetTrainerUserByUserId(int id)
        {
            return _trainerService.GetTrainerUserByUserId(id);
        }
    }
}
