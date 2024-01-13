using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class CrateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public CrateAboutCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }
        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var values = new About
            {
                AboutImage1 = request.AboutImage1,
                AboutDescription1 = request.AboutDescription1,
                AboutImage2 = request.AboutImage2,
                AboutDescription2 = request.AboutDescription2,
                AboutTitle = request.AboutTitle


            };

            await _aboutCollection.InsertOneAsync(values, cancellationToken);
        }
    }
}
