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
    public class CRUDContactUsController :  CRUDController<ContactU>
    {
        private readonly IService<ContactU> _contactUsService;
        public CRUDContactUsController(IService<ContactU> contactUService)
        : base(contactUService)
        {

        }
    }
}
