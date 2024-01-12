using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var values =await _mediator.Send(new GetAllCategoryQuery());
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand categoryCommand)
        {
           await _mediator.Send(categoryCommand);
            return RedirectToAction("Index");
        }
    }
}
