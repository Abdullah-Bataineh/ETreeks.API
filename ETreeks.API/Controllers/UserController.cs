using ETreeks.CORE.Data;
using ETreeks.CORE.DTO;
using ETreeks.CORE.Service;
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
        private  readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("uploadImage")]
        [HttpPost]
        public User UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine(@"C:\ETreeks\src\assets\images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            User item = new User();
            item.Image = fileName;
            return item;

        }
        [Route("Search/{c_name}")]
        [HttpGet]
        public List<User> Search(string c_name)
        {
            return _userService.Search(c_name); 
        }

        [Route("CreateUser")]
        [HttpPost]
        public List<KeyValuePair<string, int>> CreateUser(UserLogin userlogin)
        {

            return _userService.CreateUser(userlogin);
        }
    }
}
