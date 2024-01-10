using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class CreateTeamQueryHandler
    {
        private readonly IMongoCollection<Team> _teamCollection;

        public CreateTeamQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }
        public void Handle(CreateTeamCommand command)
        {
            var team=new Team()
            {
                Image=command.Image,
                NameSurname=command.NameSurname,
                Title=command.Title,    
            };
            _teamCollection.InsertOne(team);
        }
    }
}
