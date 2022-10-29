using ETreeks.CORE.Data;
using ETreeks.CORE.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDCategoryController : CRUDController<Category>
    {
        private readonly IService<ContactU> _contactUsService;
        public CRUDCategoryController(IService<Category> categoryUService)
        : base(categoryUService)
        {

        }
    }
}
