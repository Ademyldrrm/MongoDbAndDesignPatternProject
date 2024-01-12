using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class DeleteServiceCommandHandler
    {

        private readonly IMongoCollection<Service> _serviceCollection;
        public DeleteServiceCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }
        public async void Handle(DeleteServiceCommand serviceCommand)
        {
            var values = await _serviceCollection.DeleteOneAsync(x=>x.ServiceID == serviceCommand.Id);
           
        }
    }
}
