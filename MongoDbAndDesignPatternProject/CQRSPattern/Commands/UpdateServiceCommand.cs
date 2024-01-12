namespace MongoDbAndDesignPatternProject.CQRSPattern.Commands
{
    public class UpdateServiceCommand
    {
        public string ServiceID { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceIcon { get; set; }
        public string ServiceDescription { get; set; }
    }
}
