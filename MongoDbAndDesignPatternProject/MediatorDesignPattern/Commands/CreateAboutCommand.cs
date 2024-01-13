using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands
{
    public class CreateAboutCommand:IRequest
    {
      
        public string AboutTitle { get; set; }
        public string AboutDescription2 { get; set; }
        public string AboutDescription1 { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
    }
}
