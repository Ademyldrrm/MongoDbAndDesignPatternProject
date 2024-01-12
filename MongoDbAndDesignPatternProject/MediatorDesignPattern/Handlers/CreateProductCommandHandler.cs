using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMongoCollection<Product> _categoryCollection;

        public CreateProductCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var values = new Product
            {
                ProductName = request.ProductName,
                ProductDescription = request.ProductDescription,
                ProductImage = request.ProductImage,
                ProductPrice = request.ProductPrice,    
               

            };

            await _categoryCollection.InsertOneAsync(values, cancellationToken);
        }
    }
}
