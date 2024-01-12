using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<GetAllCategoryQueryResult>>
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public GetAllCategoryQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }
        public async Task<List<GetAllCategoryQueryResult>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var filter = Builders<Category>.Filter.Empty;
            var projection = Builders<Category>.Projection
                .Include(a => a.CategoryID)
                .Include(a => a.CategoryName);
                

            var result = await _categoryCollection.Find(filter)
                                                      .Project<GetAllCategoryQueryResult>(projection)
                                                      .ToListAsync(cancellationToken);
            return result;



        }
    }
}
