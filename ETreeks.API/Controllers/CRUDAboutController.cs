using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDAboutController : CRUDController<About>
    {
        public CRUDAboutController(IService<About> aboutService)
        : base(aboutService)
        {

        }
    }
}
