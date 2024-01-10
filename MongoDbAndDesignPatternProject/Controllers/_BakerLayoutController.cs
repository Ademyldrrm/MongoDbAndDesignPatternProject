using Microsoft.AspNetCore.Mvc;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class _BakerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
