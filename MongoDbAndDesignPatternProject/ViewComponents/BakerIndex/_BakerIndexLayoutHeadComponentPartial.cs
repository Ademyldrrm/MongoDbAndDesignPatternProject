using Microsoft.AspNetCore.Mvc;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexLayoutHeadComponentPartial:ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
