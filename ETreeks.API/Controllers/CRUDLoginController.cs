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
    public class CRUDLoginController : CRUDController<Login>
    {
        public CRUDLoginController(IService<Login> loginService)
        : base(loginService)
        {

        }
    }
}
