using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Commands;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class DeleteTeamCommandHandler
    {
        private readonly IMongoCollection<Team> _teamCollection;

        public DeleteTeamCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }
        public void Handle(DeleteTeamCommand deleteTeamCommand)
        {

            var values = Builders<Team>.Filter.Eq(X => X.TeamID, deleteTeamCommand.Id);

            _teamCollection.DeleteOne(values);
        }
    }
}
