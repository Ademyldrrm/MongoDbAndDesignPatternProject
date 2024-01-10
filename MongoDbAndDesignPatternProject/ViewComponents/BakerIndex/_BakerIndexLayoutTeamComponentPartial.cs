using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;

namespace MongoDbAndDesignPatternProject.ViewComponents.BakerIndex
{
    public class _BakerIndexLayoutTeamComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Team> _teamCollection;

        public _BakerIndexLayoutTeamComponentPartial(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _teamCollection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _teamCollection.Find(x => true).ToListAsync();
            return View(values);
        }

    }
}
