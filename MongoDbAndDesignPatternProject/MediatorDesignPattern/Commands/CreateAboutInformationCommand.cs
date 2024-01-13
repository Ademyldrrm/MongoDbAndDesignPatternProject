using MediatR;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Commands
{
    public class CreateAboutInformationCommand:IRequest
    {
        public string AboutInformationName { get; set; }
    }
}
