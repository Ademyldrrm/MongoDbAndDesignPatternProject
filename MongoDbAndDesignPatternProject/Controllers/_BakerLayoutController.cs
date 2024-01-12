using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.CQRSPattern.Handler;

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
