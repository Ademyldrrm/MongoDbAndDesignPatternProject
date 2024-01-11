using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexServiceComponentPartail:ViewComponent
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public _BakerIndexServiceComponentPartail(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _serviceCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
