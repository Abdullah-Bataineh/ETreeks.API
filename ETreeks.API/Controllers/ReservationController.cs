using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {

            _reservationService = reservationService;
        }
        [HttpPost]
        [Route("Search")]
        public List<search> Search(search search)
        {
            return _reservationService.Search(search);
        }
    }
}
