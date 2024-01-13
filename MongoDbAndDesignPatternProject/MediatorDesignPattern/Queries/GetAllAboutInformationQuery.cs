using MediatR;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries
{
    public class GetAllAboutInformationQuery:IRequest<List<GetAllAboutInformationQueryResult>>
    {
    }
}
