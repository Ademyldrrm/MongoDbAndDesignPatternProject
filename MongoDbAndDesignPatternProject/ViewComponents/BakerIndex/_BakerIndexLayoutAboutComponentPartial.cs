using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexLayoutAboutComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<About> _aboutCollection;
        private readonly IMongoCollection<AboutInformation> _aboutInformationCollection;
        public _BakerIndexLayoutAboutComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _aboutInformationCollection = database.GetCollection<AboutInformation>(databaseSettings.AboutInformtionCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutCollection.Find(x => true).FirstOrDefaultAsync();

            var abouttitle = values.AboutTitle;
            ViewBag.Title = abouttitle;
            var AboutImage1 = values.AboutImage1;
            ViewBag.Image1 = AboutImage1;
            var AboutImage2 = values.AboutImage2;
            ViewBag.Image2 = AboutImage2;
            var Description1 = values.AboutDescription1;
            ViewBag.Description1 = Description1;
            var Description2 = values.AboutDescription2;
            ViewBag.Description2 = Description2;

            var values2=await _aboutInformationCollection.Find(x => true).ToListAsync();
            return View(values2);
        }
    }
}
