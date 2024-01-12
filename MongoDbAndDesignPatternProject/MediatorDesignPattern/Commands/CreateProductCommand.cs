using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDbAndDesignPatternProject.DAL.Entities;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands
{
    public class CreateProductCommand:IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

        public string CategoryID { get; set; }
    }
}
