using MediatR;
using MongoDB.Driver;
using MongoDbAndDesignPatternProject.DAL.Entities;
using MongoDbAndDesignPatternProject.DAL.Settings;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        public CreateCategoryCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }
        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var values = new Category
            {
                CategoryName = request.CategoryName,
               
            };

            // Add the AboutArticle object to the MongoDB collection
            await _categoryCollection.InsertOneAsync(values, cancellationToken);
        }
    }
}
