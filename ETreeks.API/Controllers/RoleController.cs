using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IService<Role> _roleService;
        public RoleController(IService<Role> roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public bool CreateRole(Role role)
        {
            return _roleService.Create(role);
        }
        [HttpPut]
        public bool UpdateRole(Role role)
        {
            return _roleService.Update(role);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteRole(int id)
        {
            return _roleService.Delete(id);
        }
        [HttpGet]
        public List<Role> GetAll()
        {
            return _roleService.GetAll();
        }
        [HttpGet]
        [Route("GetById/{id}")]
        public Role GetRoleById(int id)
        {
            return GetRoleById(id);
        }
    }
}
