namespace MongoDbAndDesignPatternProject.CQRSPattern.Commands
{
    public class DeleteServiceCommand
    {
        public DeleteServiceCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
