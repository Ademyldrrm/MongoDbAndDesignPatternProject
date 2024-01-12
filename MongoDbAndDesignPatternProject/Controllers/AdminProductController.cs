using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IMediator _mediator;

        public AdminProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var values =await _mediator.Send(new GetAllProductQuery());
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand productCommand)
        {
            await _mediator.Send(productCommand);
            return RedirectToAction("Index");
        }
    }
}