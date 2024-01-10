namespace MongoDbAndDesignPatternProject.CQRSPattern.Commands
{
    public class DeleteTeamCommand
    {
        public DeleteTeamCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
