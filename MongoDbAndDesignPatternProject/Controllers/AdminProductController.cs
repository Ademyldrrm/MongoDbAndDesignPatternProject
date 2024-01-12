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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var values = await _mediator.Send(new GetAllCategoryQuery());

            List<SelectListItem> messageCategoryList = (from mc in values
                                                        select new SelectListItem
                                                        {
                                                            Text = mc.CategoryName,
                                                            Value = mc.CategoryID.ToString()
                                                        }).ToList();
            ViewBag.messageCategoryList = messageCategoryList;
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