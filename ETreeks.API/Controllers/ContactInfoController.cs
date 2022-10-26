using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IService<ContactInfo> _service;
        public ContactInfoController(IService<ContactInfo> service)
        {
            _service = service;
        }
        [HttpPost]
        public bool CreateCategory(ContactInfo contactInfo)
        {
            return _service.Create(contactInfo);
        }
        [HttpPut]
        [Route("Update/{id}")]
        public bool UpdateCategory(ContactInfo contactInfo)
        {
            return _service.Update(contactInfo);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return _service.Delete(id);
        }
        [HttpGet]
        public List<ContactInfo> GetAll() { return _service.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public ContactInfo GetCategoryById(int id)
        {
            return _service.GetById(id);
        }
    }
}
