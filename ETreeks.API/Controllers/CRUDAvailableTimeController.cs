using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    public class CRUDAvailableTimeController : CRUDController<AvailableTime>
    {
        public CRUDAvailableTimeController(IService<AvailableTime> availableTimeService)
        : base(availableTimeService)
        {

        }
    }
}
