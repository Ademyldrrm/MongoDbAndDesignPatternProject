using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class CreateServiceQueryHandler
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        public CreateServiceQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }
        public void Handle(CreateServiceCommand command)
        {
            var service=new Service()
            {
                ServiceDescription=command.ServiceDescription,
                ServiceIcon=command.ServiceIcon,
                ServiceTitle=command.ServiceTitle,
            };
            _serviceCollection.InsertOne(service);
        }
    }
}
