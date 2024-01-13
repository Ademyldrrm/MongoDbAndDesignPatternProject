using MediatR;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries
{
    public class GetAllAboutQuery:IRequest<List<GetAllAboutQueryResult>>
    {
    }
}
