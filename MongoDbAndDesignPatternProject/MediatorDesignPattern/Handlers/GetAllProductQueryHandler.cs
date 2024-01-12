using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductQueryResult>>
    {
        private readonly IMongoCollection<Product> _categoryCollection;

        public GetAllProductQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }
        public async Task<List<GetAllProductQueryResult>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var filter = Builders<Product>.Filter.Empty;
            var projection = Builders<Product>.Projection
                .Include(a => a.ProductID)
                .Include(a => a.ProductName)
                .Include(a => a.ProductPrice)
                .Include(a => a.ProductImage)
                .Include(a => a.ProductDescription);


            var result = await _categoryCollection.Find(filter)
                                                      .Project<GetAllProductQueryResult>(projection)
                                                      .ToListAsync(cancellationToken);
            return result;

        }
    }
}
