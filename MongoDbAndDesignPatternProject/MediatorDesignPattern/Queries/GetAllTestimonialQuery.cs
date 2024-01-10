using MediatR;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries
{
    public class GetAllTestimonialQuery:IRequest<List<GetAllTestimonialQueryresult>>
    {
    }
}
