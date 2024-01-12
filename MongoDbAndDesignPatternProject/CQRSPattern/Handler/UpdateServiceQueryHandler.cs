using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.CQRSPattern.Results;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class UpdateServiceQueryHandler
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public UpdateServiceQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }
        public  void Handle(UpdateServiceCommand serviceCommand)
        {
            var filter = Builders<Service>.Filter.Eq(x => x.ServiceID, serviceCommand.ServiceID);

            var update = Builders<Service>.Update
                .Set(x => x.ServiceDescription, serviceCommand.ServiceDescription)  
                .Set(x => x.ServiceIcon, serviceCommand.ServiceIcon)               
                .Set(x => x.ServiceTitle, serviceCommand.ServiceTitle);              

            var result = _serviceCollection.UpdateOne(filter, update);

        }
    }
}
