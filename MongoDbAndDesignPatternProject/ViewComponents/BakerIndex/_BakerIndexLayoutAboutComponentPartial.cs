using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexLayoutAboutComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<About> _aboutCollection;
        public _BakerIndexLayoutAboutComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()

        {
            var values = await _aboutCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
