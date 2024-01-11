using MediatR;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries
{
    public class GettestimonialCountQuery:IRequest<GetTestimonialCountQueryResult>
    {
    }
}
