using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Queries;
using MongoDbAndDesignPatternProject.CQRSPattern.Results;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class GetServiceByIdQueryHandler
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public GetServiceByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery byIdQuery)
        {
            var values = await _serviceCollection.Find(x => x.ServiceID == byIdQuery.Id).FirstOrDefaultAsync();

            var result = new GetServiceByIdQueryResult
            {
                ServiceID = values.ServiceID,
                ServiceDescription=values.ServiceDescription,
                ServiceIcon=values.ServiceIcon,
                ServiceTitle=values.ServiceTitle,
            };

            return result;

        }
    }
}
