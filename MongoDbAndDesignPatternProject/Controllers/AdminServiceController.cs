using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.CQRSPattern.Handler;
using MongoDbAndDesignPatternProject.CQRSPattern.Queries;
using System.Runtime.CompilerServices;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly GetAllServiceQueryHandler _servicequeryHandler;
        private readonly CreateServiceQueryHandler _createService;
        private readonly DeleteServiceCommandHandler _deleteService;
        private readonly GetServiceByIdQueryHandler _getByIdQueryHandler;
        private readonly UpdateServiceQueryHandler _updateService;

        public AdminServiceController(GetAllServiceQueryHandler servicequeryHandler, CreateServiceQueryHandler createService, DeleteServiceCommandHandler deleteService, GetServiceByIdQueryHandler getByIdQueryHandler, UpdateServiceQueryHandler updateService)
        {
            _servicequeryHandler = servicequeryHandler;
            _createService = createService;
            _deleteService = deleteService;
            _getByIdQueryHandler = getByIdQueryHandler;
            _updateService = updateService;
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
        public IActionResult DeleteService(string id)
        {
            _deleteService.Handle(new DeleteServiceCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
         public  async Task<IActionResult> UpdateService(string id)
        {

            var values = await _getByIdQueryHandler.Handle(new GetServiceByIdQuery(id));
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            _updateService.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
