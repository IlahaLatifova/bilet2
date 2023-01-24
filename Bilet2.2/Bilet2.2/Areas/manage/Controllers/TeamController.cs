using Microsoft.AspNetCore.Mvc;

namespace Bilet2._2.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
