using Microsoft.AspNetCore.Mvc;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexServiceComponentPartail:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
