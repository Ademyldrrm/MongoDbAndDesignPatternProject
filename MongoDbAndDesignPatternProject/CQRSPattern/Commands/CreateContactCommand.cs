namespace MongoDbAndDesignPatternProject.CQRSPattern.Commands
{
    public class CreateContactCommand
    {
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
