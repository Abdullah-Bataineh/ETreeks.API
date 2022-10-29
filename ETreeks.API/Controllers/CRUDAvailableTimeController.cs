using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDAvailableTimeController : CRUDController<AvailableTime>
    {
        public CRUDAvailableTimeController(IService<AvailableTime> availableTimeService)
        : base(availableTimeService)
        {

        }
    }
}
