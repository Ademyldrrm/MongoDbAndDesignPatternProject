namespace MongoDbAndDesignPatternProject.CQRSPattern.Queries
{
    public class GetServiceByIdQuery
    {
        public GetServiceByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
