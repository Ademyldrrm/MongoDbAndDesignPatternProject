using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Results;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class GetAllContactQueryHandler
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        public GetAllContactQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
        }
        public List<GetAllContactQueryResult> Handle()
        {
            var values = _contactCollection.Find(x => true).ToList();
            var results = values.Select(service => new GetAllContactQueryResult
            {
               ContactID = service.ContactID,
               EMail = service.EMail,
               Message = service.Message,
               Subject = service.Subject,
               NameSurname = service.NameSurname
               
            }).ToList();

            return results;
        }
    }
}
