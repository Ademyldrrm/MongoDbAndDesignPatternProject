using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAndDesignPatternProject.DAL.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDescription2 { get; set; }
        public string AboutDescription1 { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
    }
}
