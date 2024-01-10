using Amazon.SecurityToken.Model;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.CQRSPattern.Results;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.CQRSPattern.Handler
{
    public class GetTeamQueryHandler
    {
        private readonly IMongoCollection<Team> _teamCollection;

        public GetTeamQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }
        public List<GetTeamQueryResult> Handle()
        {
            // MongoDB sorgusu ile belgeleri çekme
            var values = _teamCollection.Find(FilterDefinition<Team>.Empty).ToList();

            // Belgeyi GetAboutQueryResult tipine dönüştürme
            var result = values.Select(team => new GetTeamQueryResult
            {
                TeamID = team.TeamID,
                Image=team.Image,
                NameSurname=team.NameSurname,
                Title = team.Title

            }).ToList();

            return result;
        }
    }
}
