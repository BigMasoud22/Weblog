using Microsoft.AspNetCore.Mvc;
using Model;

namespace PersonalWeblog.Areas.Main.Controllers
{
    [Area("Main")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
