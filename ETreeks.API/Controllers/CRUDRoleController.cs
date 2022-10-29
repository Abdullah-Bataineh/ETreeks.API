using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDRoleController : CRUDController<Role>
    {
        public CRUDRoleController(IService<Role> rolService)
        : base(rolService)
        {

        }
    }
}
