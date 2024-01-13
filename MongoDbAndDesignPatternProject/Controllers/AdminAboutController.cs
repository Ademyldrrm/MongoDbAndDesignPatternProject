using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IMediator _mediator;

        public AdminAboutController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var values =await _mediator.Send(new GetAllAboutQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand createAboutCommand)
        {
            await _mediator.Send(createAboutCommand);
            return RedirectToAction("Index");
        }
    }
}
