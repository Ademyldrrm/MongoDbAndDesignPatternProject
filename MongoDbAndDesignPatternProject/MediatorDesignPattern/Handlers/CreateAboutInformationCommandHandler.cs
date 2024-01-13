using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class CreateAboutInformationCommandHandler : IRequestHandler<CreateAboutInformationCommand>
    {
        private readonly IMongoCollection<AboutInformation> _aboutInformationCollection;

        public CreateAboutInformationCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutInformationCollection = database.GetCollection<AboutInformation>(databaseSettings.AboutInformtionCollectionName);
        }
        public async Task Handle(CreateAboutInformationCommand request, CancellationToken cancellationToken)
        {
            var values = new AboutInformation
            {
                AboutInformationName = request.AboutInformationName,


            };

            await _aboutInformationCollection.InsertOneAsync(values, cancellationToken);
        }
    }
}
