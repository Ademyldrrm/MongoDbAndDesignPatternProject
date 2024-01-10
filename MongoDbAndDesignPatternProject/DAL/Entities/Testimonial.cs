using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAndDesignPatternProject.DAL.Entities
{
    public class Testimonial
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
