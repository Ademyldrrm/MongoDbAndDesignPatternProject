using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Results
{
    public class GetAllAboutInformationQueryResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutInformationID { get; set; }
        public string AboutInformationName { get; set; }
    }
}
