
using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class GetAllAboutInformationQueryHandler : IRequestHandler<GetAllAboutInformationQuery, List<GetAllAboutInformationQueryResult>>
    {
        private readonly IMongoCollection<AboutInformation> _aboutInformationCollection;

        public GetAllAboutInformationQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutInformationCollection = database.GetCollection<AboutInformation>(databaseSettings.AboutInformtionCollectionName);
        }
        public async Task<List<GetAllAboutInformationQueryResult>> Handle(GetAllAboutInformationQuery request, CancellationToken cancellationToken)
        {
            var filter = Builders<AboutInformation>.Filter.Empty;
            var projection = Builders<AboutInformation>.Projection
                .Include(a => a.AboutInformationID)
                .Include(a => a.AboutInformationName);
             


            var result = await _aboutInformationCollection.Find(filter)
                                                      .Project<GetAllAboutInformationQueryResult>(projection)
                                                      .ToListAsync(cancellationToken);
            return result;
        }
    }
}
