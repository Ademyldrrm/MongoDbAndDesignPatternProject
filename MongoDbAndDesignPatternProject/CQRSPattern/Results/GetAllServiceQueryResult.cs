namespace MongoDbAndDesignPatternProject.CQRSPattern.Results
{
    public class GetAllServiceQueryResult
    {
        public string ServiceID { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceIcon { get; set; }
        public string ServiceDescription { get; set; }
    }
}
