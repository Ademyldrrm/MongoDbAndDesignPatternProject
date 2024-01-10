namespace MongoDbAndDesignPatternProject.CQRSPattern.Results
{
    public class GetTeamByIdQueryResult
    {
        public string TeamID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
