using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.CQRSPattern.Handler;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly GetAllContactQueryHandler _ContactCollection;

        public AdminContactController(GetAllContactQueryHandler contactCollection)
        {
            _ContactCollection = contactCollection;
        }

        public IActionResult Index()
        {
            var values = _ContactCollection.Handle();
            return View(values);
        }
    }
}
