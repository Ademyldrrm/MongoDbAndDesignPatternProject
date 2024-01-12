using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAndDesignPatternProject.DAL.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
