using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands
{
    public class CreateTestimonialCommand:IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
