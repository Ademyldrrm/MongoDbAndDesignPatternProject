using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAndDesignPatternProject.DAL.Entities
{
    public class AboutInformation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutInformationID { get; set; }
        public string AboutInformationName { get; set; }
    }
}
