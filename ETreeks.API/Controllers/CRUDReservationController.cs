using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDReservationController : CRUDController<Reservation>
    {
        
        public CRUDReservationController(IService<Reservation> reservationUService)
        : base(reservationUService)
        {

        }
    }
}
