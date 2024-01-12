using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDbAndDesignPatternProject.DAL.Entities;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Results
{
    public class GetAllCategoryQueryResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
