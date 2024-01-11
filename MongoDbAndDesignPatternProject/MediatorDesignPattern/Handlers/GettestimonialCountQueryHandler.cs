using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class GettestimonialCountQueryHandler : IRequestHandler<GettestimonialCountQuery, GetTestimonialCountQueryResult>
    {
        private readonly IMongoCollection<Testimonial> _collection;
        public GettestimonialCountQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var databse = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = databse.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }
        public async Task<GetTestimonialCountQueryResult> Handle(GettestimonialCountQuery request, CancellationToken cancellationToken)
        {
            // MongoDB'den testimonial sayısını al
            long count = await _collection.CountDocumentsAsync(FilterDefinition<Testimonial>.Empty);

            // Sonucu GetTestimonialCountQueryResult nesnesine doldur
            var result = new GetTestimonialCountQueryResult
            {
                TestimonialCount = count
            };

            return result;

        }
    }
}
