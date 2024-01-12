namespace MongoDbAndDesignPatternProject.CQRSPattern.Results
{
    public class GetAllContactQueryResult
    {
        public string ContactID { get; set; }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
