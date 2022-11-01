using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : Controller
    {
        private readonly IJWTService _service;
        public JWTController(IJWTService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Auth([FromBody] Login login)
        {
            var token = _service.Auth(login);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }

        }

    }
}
