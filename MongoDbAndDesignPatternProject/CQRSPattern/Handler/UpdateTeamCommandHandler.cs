using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class UpdateTeamCommandHandler
    {

        private readonly IMongoCollection<Team> _teamCollection;

        public UpdateTeamCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }
        public void Handle(UpdateTeamCommand updateTeamCommand)
        {
            var filter = Builders<Team>.Filter.Eq(a => a.TeamID, updateTeamCommand.TeamID);

            var update = Builders<Team>.Update
                .Set(a => a.Title, updateTeamCommand.Title)
                .Set(a => a.NameSurname, updateTeamCommand.NameSurname)
                .Set(a => a.Image, updateTeamCommand.Image);

            _teamCollection.UpdateOne(filter, update);
        }
    }
}


