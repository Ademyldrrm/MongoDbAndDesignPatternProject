using MediatR;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries
{
    public class GetAllProductQuery: IRequest<List<GetAllProductQueryResult>>
    {
    }
}
