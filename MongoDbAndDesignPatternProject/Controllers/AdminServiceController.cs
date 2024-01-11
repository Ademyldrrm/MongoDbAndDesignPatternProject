using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.CQRSPattern.Handler;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly GetAllServiceQueryHandler _servicequeryHandler;
        private readonly CreateServiceQueryHandler _createService;

        public AdminServiceController(GetAllServiceQueryHandler servicequeryHandler, CreateServiceQueryHandler createService)
        {
            _servicequeryHandler = servicequeryHandler;
            _createService = createService;
        }

        public IActionResult Index()
        {
            var values = _servicequeryHandler.Handle(); 
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceCommand command) 
        {
            _createService.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
