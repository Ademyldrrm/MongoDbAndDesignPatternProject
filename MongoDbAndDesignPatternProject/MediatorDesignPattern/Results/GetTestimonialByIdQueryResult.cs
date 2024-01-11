using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Results
{
    public class GetTestimonialByIdQueryResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
