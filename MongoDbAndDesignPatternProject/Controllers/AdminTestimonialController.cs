using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminTestimonialController : Controller
    {
        private readonly IMediator _mediator;

        public AdminTestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public  async Task<IActionResult> Index()
        {
            var values =await _mediator.Send(new GetAllTestimonialQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _mediator.Send(new RemoveTestimonialCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdtaeTestimonial(string id)
        {
            var values = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdtaeTestimonial(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> TestimonialCount(GettestimonialCountQuery countQuery)
        {
            var count=await _mediator.Send(countQuery); 
            return View(count);
        }
    }
}
