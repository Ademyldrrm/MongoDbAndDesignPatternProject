using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands
{
    public class CreateCategoryCommand : IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
