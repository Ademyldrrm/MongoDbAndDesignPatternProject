namespace MongoDbAndDesignPatternProject.CQRSPattern.Queries
{
    public class GetTeamByIdQuery
    {
        public GetTeamByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

    }

}
