using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexLayoutTestimonialComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Testimonial> _tesimonialCollection;

        public _BakerIndexLayoutTestimonialComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _tesimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
                var values=await _tesimonialCollection.Find(x=> true).ToListAsync();
            return View(values);
        }
    }
}
