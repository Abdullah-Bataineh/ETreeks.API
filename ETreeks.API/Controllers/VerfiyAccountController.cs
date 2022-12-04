using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerfiyAccountController : ControllerBase
    {
        private readonly IVerfiyAccountService _verfiyAccountService;
        public VerfiyAccountController(IVerfiyAccountService verfiyAccountService)
        {
            _verfiyAccountService= verfiyAccountService;
        }

        [HttpPost]
        [Route("VerfiyAccount/{code}/{id}")]
        public bool VerfiyAccount(int code,int id)
        {
            return _verfiyAccountService.Verfiy(code,id);
        }
    }
}
