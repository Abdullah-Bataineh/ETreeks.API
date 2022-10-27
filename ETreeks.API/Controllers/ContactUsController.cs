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
    public class ContactUsController : ControllerBase
    {
        private readonly IService<ContactU> _contactUsService;
        public ContactUsController(IService<ContactU> contactUsService)
        {
            _contactUsService = contactUsService;
        }
        [HttpPost]
        public bool CreateLogin(ContactU contactU)
        {
            return _contactUsService.Create(contactU);
        }
        [HttpPut]
        [Route("Update/{id}")]
        public bool UpdateLogin(ContactU contactU)
        {
            return _contactUsService.Update(contactU);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteLogin(int id)
        {
            return _contactUsService.Delete(id);
        }
        [HttpGet]
        public List<ContactU> GetAll() { return _contactUsService.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public ContactU GetLoginById(int id)
        {
            return _contactUsService.GetById(id);
        }
    }
}
