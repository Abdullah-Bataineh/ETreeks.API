using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDHomeController : CRUDController<HomePage>
    {
        public CRUDHomeController(IService<HomePage> Homeservice) : base(Homeservice)
        {
        }
    }
}
