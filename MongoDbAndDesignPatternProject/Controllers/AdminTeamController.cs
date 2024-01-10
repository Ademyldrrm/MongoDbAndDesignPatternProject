using Microsoft.AspNetCore.Mvc;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminTeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
