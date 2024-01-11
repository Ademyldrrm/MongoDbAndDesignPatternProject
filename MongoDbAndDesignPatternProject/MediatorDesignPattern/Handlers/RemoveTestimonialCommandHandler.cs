using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IMongoCollection<Testimonial> _tesimonialCollection;

        public RemoveTestimonialCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _tesimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }
        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var result = await _tesimonialCollection.DeleteOneAsync(x => x.TestimonialID == request.Id);
        }
    }
}
