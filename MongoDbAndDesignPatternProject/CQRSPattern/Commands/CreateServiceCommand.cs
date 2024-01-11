namespace MongoDbAndDesignPatternProject.CQRSPattern.Commands
{
    public class CreateServiceCommand
    {
        public string ServiceTitle { get; set; }
        public string ServiceIcon { get; set; }
        public string ServiceDescription { get; set; }
    }
}
