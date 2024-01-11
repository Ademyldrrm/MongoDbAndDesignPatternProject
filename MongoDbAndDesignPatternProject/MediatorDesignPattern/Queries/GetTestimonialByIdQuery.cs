using MediatR;
using MongoDbAndDesignPatternProject.MediatorDesignPattern.Results;

namespace MongoDbAndDesignPatternProject.MediatorDesignPattern.Queries
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResult>
    {
        public string Id { get; set; }

        public GetTestimonialByIdQuery(string id)
        {
            Id = id;
        }
    }
}
