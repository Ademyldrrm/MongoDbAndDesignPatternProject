using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class UpdateTestimonialCommandHandler:IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        public UpdateTestimonialCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client=new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var filter = Builders<Testimonial>.Filter.Eq(t => t.TestimonialID, request.TestimonialID);

        var update = Builders<Testimonial>.Update
            .Set(t => t.NameSurname, request.NameSurname)
            .Set(t => t.Description, request.Description)
            .Set(t => t.Image, request.Image)
            .Set(t => t.Title, request.Title);

        var updateResult = await _testimonialCollection.UpdateOneAsync(filter, update,null, cancellationToken);
        }
    }
}
