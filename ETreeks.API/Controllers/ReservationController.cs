﻿using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Service;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly IReservationService _reservationService;
        private readonly IService<Login> _service;
        public ReservationController(IReservationService reservationService, IService<Login> service)
        {

            _reservationService = reservationService;
            _service = service;
        }
        [HttpPost]
        [Route("Search")]
        public List<search> Search(search search)
        {
            return _reservationService.Search(search);
        }
        [HttpGet]
        [Route("getreservation/{t_id}")]
        public List<ReservationAccept> GetReservation(int t_id)
        {
           return _reservationService.GetReservation(t_id);
        }
        [HttpGet]
        [Route("getreservationbyuser/{u_id}")]
        public List<ReservationAccept> GetReservationByUser(int u_id)
        {
            return _reservationService.GetReservationByUser(u_id);
        }
        [HttpGet]
        [Route("getuserforeachcourse/{t_id}")]
        public List<UserByCourse> GetUserOfEachCourse(int t_id)
        {
            return _reservationService.GetUserOfEachCourse(t_id);   
        }

        [HttpPost]
        [Route("SendEmail/{login_id}/{status}")]
        public void SendEmail(int login_id,int status)
        {

            var login = _service.GetById(login_id);
            MimeMessage mail = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress("ETreeks", "etrreks123@gmail.com");
            MailboxAddress emailTo = new MailboxAddress("Email verification code:" + login.Verify_Code, login.Email);
            BodyBuilder bodyBuilder = new BodyBuilder();
            mail.From.Add(emailFrom);
            mail.To.Add(emailTo);
          
           
            if (status == 1)
            {
                mail.Subject = "Booking Accepted";
                bodyBuilder.HtmlBody = "<td>        <div style='border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px' align='center' class='m_-9056096535776185231mdv2rw'>\r\n        <img src='https://i.postimg.cc/2SJbh5Gz/Green-Modern-Education-Online-Course-Logo-2.png' width ='170' height='110' aria-hidden='true' style='margin-bottom:16px' alt='Google' class='CToWUd' data-bit='iit'>        <div style='font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word'>            <div style='font-size:24px'> </div>       </div>        <div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left'>            ETreeks Booking Status For            <a style='font-weight:bold'>" + login.Email + "</a> . <br><br>            <br>            <div style='text-align:center;font-size:36px;margin-top:20px;line-height:44px'> Your Booking was accepted </div> <br>            <br> <br>         </div>        </div>\r\n            <div style='text-align:left'><div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center'>               <div>\r\n                    You received this email to let you know about important changes to your ETreeks Account and services.</div><div style='direction:ltr'>© 2022 ETreeks LLC,                </div></div></div></td>";
            }
            else
            {
                mail.Subject = "Booking Rejected";
                bodyBuilder.HtmlBody = "<td>        <div style='border-style:solid;border-width:thin;border-color:#dadce0;border-radius:8px;padding:40px 20px' align='center' class='m_-9056096535776185231mdv2rw'>\r\n        <img src='https://i.postimg.cc/2SJbh5Gz/Green-Modern-Education-Online-Course-Logo-2.png' width ='170' height='110' aria-hidden='true' style='margin-bottom:16px' alt='Google' class='CToWUd' data-bit='iit'>        <div style='font-family:'Google Sans',Roboto,RobotoDraft,Helvetica,Arial,sans-serif;border-bottom:thin solid #dadce0;color:rgba(0,0,0,0.87);line-height:32px;padding-bottom:24px;text-align:center;word-break:break-word'>            <div style='font-size:24px'> </div>       </div>        <div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;font-size:14px;color:rgba(0,0,0,0.87);line-height:20px;padding-top:20px;text-align:left'>            ETreeks Booking Status For             <a style='font-weight:bold'>" + login.Email + "</a> . <br><br>              <br>            <div style='text-align:center;font-size:36px;margin-top:20px;line-height:44px'>Your Booking was Rejected</div> <br>             <br> <br>         </div>        </div>\r\n            <div style='text-align:left'><div style='font-family:Roboto-Regular,Helvetica,Arial,sans-serif;color:rgba(0,0,0,0.54);font-size:11px;line-height:18px;padding-top:12px;text-align:center'>               <div>\r\n                    You received this email to let you know about important changes to your ETreeks Account and services.</div><div style='direction:ltr'>© 2022 ETreeks LLC,                </div></div></div></td>";
            }
            mail.Body = bodyBuilder.ToMessageBody();
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("imap.gmail.com", 465, true);
            smtpClient.Authenticate("etrreks123@gmail.com", "waozndqxwxgzvirc");
            smtpClient.Send(mail);
            smtpClient.Disconnect(true);
            smtpClient.Dispose();

        }
    }
}
