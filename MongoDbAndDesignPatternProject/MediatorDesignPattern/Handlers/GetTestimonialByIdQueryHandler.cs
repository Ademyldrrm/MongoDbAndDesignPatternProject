using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        public GetTestimonialByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client=new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
                
        }
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var filter = Builders<Testimonial>.Filter.Eq(t => t.TestimonialID, request.Id);
            var testimonial = await _testimonialCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialID = testimonial.TestimonialID,
                Description = testimonial.Description,
                Image = testimonial.Image,
                NameSurname = testimonial.NameSurname,
                Title = testimonial.Title
            };
        }
    }
}
