using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class GetAllTestimonialQueryHandler : IRequestHandler<GetAllTestimonialQuery, List<GetAllTestimonialQueryresult>>
    {
        private readonly IMongoCollection<Testimonial> _tesimonialCollection;

        public GetAllTestimonialQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _tesimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }
        public  async Task<List<GetAllTestimonialQueryresult>> Handle(GetAllTestimonialQuery request, CancellationToken cancellationToken)
        {
            var filter = Builders<Testimonial>.Filter.Empty;
            var projection = Builders<Testimonial>.Projection
                .Include(a => a.TestimonialID)
                .Include(a => a.NameSurname)
                .Include(a => a.Title)
                .Include(a => a.Image)
                .Include(a => a.Description);
               

            var result = await _tesimonialCollection.Find(filter)
                                                      .Project<GetAllTestimonialQueryresult>(projection)
                                                      .ToListAsync(cancellationToken);
            return result;
        }
    }
}
