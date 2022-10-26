using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
