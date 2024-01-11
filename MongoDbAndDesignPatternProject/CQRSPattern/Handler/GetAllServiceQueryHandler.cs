using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Results;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class GetAllServiceQueryHandler
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public GetAllServiceQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }
        public  List<GetAllServiceQueryResult> Handle()
        {
            var values = _serviceCollection.Find(x => true).ToList();
            var results = values.Select(service => new GetAllServiceQueryResult
            {
                ServiceID = service.ServiceID,
                ServiceDescription = service.ServiceDescription,
                ServiceIcon = service.ServiceIcon,
                ServiceTitle = service.ServiceTitle,
            }).ToList();

            return results;
        }
    }
}
