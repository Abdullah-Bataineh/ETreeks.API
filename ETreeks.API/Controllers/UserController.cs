using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using ETreeks.INFRA.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _service;
        public UserController(IService<User> service)
        {
            _service = service;
        }
        [HttpPost]
        public bool CreateUser(User user)
        {
            return _service.Create(user);
        }
        [HttpPut]
        [Route("Update/{id}")]
        public bool UpdateUser(User user)
        {
            return _service.Update(user);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteUser(int id)
        {
            return _service.Delete(id);
        }
        [HttpGet]
        public List<User> GetAllUser() { return _service.GetAll(); }
        [HttpGet]
        [Route("GetById/{id}")]
        public User GetUserById(int id)
        {
            return _service.GetById(id);
        }
        [HttpGet]
        [Route("UploadImage")]
        public User UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Image", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            User    user = new User();
            user.Image = fileName;
            return user;
        }
    }
}
