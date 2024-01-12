using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexLayoutProductComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Product> _products;
        public _BakerIndexLayoutProductComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _products = database.GetCollection<Product>(databaseSettings.ProductCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _products.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
