using MediatR;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands
{
    public class RemoveTestimonialCommand:IRequest
    {
        public RemoveTestimonialCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
