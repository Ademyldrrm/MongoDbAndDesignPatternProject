using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexLayoutFactsComponentPartial:ViewComponent
    {
        private IMongoCollection<Team> _teamCollection;
        private IMongoCollection<Testimonial> _testimonialCollection;
        private IMongoCollection<Product> _productCollection;
        private IMongoCollection<Contact> _contactCollection;
        
        public _BakerIndexLayoutFactsComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
            
        }
        public IViewComponentResult Invoke()
        {
            var teamCount = _teamCollection.CountDocuments(FilterDefinition<Team>.Empty);
            var testimonialCount = _testimonialCollection.CountDocuments(FilterDefinition<Testimonial>.Empty);
            var productCount = _productCollection.CountDocuments(FilterDefinition<Product>.Empty);
            var contactCount = _contactCollection.CountDocuments(FilterDefinition<Contact>.Empty);

            ViewBag.TeamCount = teamCount;
            ViewBag.TestimonialCount = testimonialCount;
            ViewBag.ProductCount = productCount;
            ViewBag.ContactCount = contactCount;    
            return View();  
        }
    }
}
