using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class CreateContactQueryHandler
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        public CreateContactQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
        }
        public void Handle(CreateContactCommand createContact)
        {
            var values = new Contact()
            {
                EMail = createContact.EMail,
                Message = createContact.Message,
                Subject = createContact.Subject,
                NameSurname = createContact.NameSurname
            };
            _contactCollection.InsertOne(values);
        }
    }
}
