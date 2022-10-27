using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IService<Login> _loginService;
        public LoginController(IService<Login> loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public bool CreateLogin(Login login)
        {
            return _loginService.Create(login);
        }
        [HttpPut]
        [Route("Update/{id}")]
        public bool UpdateLogin(Login login)
        {
            return _loginService.Update(login);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteLogin(int id)
        {
            return _loginService.Delete(id);
        }
        [HttpGet]
        public List<Login> GetAll() { return _loginService.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public Login GetLoginById(int id)
        {
            return _loginService.GetById(id);
        }
    }
}
