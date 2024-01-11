using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAndDesignPatternProject.DAL.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceID { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceIcon { get; set; }
        public string ServiceDescription { get; set; }
    }
}
