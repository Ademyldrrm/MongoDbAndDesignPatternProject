using Microsoft.AspNetCore.Mvc;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.CQRSPattern.Handler;

namespace MongoDbAndDesignPatternProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly CreateContactQueryHandler _contactQueryHandler;

        public ContactController(CreateContactQueryHandler contactQueryHandler)
        {
            _contactQueryHandler = contactQueryHandler;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand createContactCommand)
        {
            _contactQueryHandler.Handle(createContactCommand);
            return RedirectToAction("Index");
        }
    }
}
