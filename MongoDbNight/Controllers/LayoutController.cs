using Microsoft.AspNetCore.Mvc;

namespace MongoDbNight.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
