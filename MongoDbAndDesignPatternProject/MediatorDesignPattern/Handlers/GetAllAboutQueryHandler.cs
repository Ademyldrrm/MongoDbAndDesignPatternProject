using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQuery, List<GetAllAboutQueryResult>>
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public GetAllAboutQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }
        public async Task<List<GetAllAboutQueryResult>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
        {
            var filter = Builders<About>.Filter.Empty;
            var projection = Builders<About>.Projection
                .Include(a => a.AboutID)
                .Include(a => a.AboutTitle)
                .Include(a => a.AboutDescription1)
                .Include(a => a.AboutDescription2)
                .Include(a => a.AboutImage1)
                .Include(a => a.AboutImage1);


            var result = await _aboutCollection.Find(filter)
                                                      .Project<GetAllAboutQueryResult>(projection)
                                                      .ToListAsync(cancellationToken);
            return result;
        }
    }
}
