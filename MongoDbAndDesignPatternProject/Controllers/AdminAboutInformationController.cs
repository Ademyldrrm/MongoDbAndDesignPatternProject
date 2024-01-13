using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminAboutInformationController : Controller
    {
        private readonly IMediator _mediator;

        public AdminAboutInformationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {

            var values = await _mediator.Send(new GetAllAboutInformationQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateInformation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateInformation(CreateAboutInformationCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
