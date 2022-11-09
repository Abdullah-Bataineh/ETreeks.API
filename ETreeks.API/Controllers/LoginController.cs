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

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {

            _loginService = loginService;
        }
        [HttpPost]
        [Route("SendWhatsapp/{id}")]
        public async Task<HttpResponseMessage> SendWhatspp(int id)
        {
            string phonenumber = _loginService.GetPhoneNumber(id);
            string _phonenumber ="+962"+ phonenumber.Substring(0);
            
            var my_jsondata = new
            {
                token = "nskumfqyf35lk0d2",
                to = _phonenumber,
                body = "hi"
            };
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.ultramsg.com/instance22564/messages/chat?token={my_jsondata.token}&to={my_jsondata.to}&body={my_jsondata.body}"))
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
    }
}
