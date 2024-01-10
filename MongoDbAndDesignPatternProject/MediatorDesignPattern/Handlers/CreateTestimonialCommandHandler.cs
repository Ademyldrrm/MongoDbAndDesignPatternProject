using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IMongoCollection<Testimonial> _tesimonialCollection;

        public CreateTestimonialCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _tesimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }
        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = new Testimonial
            {
                Description = request.Description,
                Image = request.Image,
                NameSurname = request.NameSurname,
                Title = request.Title   
            };

            // Add the AboutArticle object to the MongoDB collection
            await _tesimonialCollection.InsertOneAsync(values, cancellationToken);
        }
    }
}
