using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
