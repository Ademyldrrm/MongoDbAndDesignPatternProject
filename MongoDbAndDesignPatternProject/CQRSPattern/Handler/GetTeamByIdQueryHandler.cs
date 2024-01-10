using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Queries;
using MongoDbAndDesignPatternProject.CQRSPattern.Results;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class GetTeamByIdQueryHandler
    {
        private readonly IMongoCollection<Team> _teamCollection;

        public GetTeamByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }
        public GetTeamByIdQueryResult Handle(GetTeamByIdQuery getTeamByIdQuery)
        {

            var filter = Builders<Team>.Filter.Eq(x => x.TeamID, getTeamByIdQuery.Id);


            var team = _teamCollection.Find(filter).FirstOrDefault();


            var result = new GetTeamByIdQueryResult
            {
                TeamID = team.TeamID,
                Image = team.Image,
                NameSurname = team.NameSurname,
                Title = team.Title,
            };

            return result;
        }
    }
}
