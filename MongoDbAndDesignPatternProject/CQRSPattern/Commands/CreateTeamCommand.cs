namespace MongoDbAndDesignPatternProject.CQRSPattern.Commands
{
    public class CreateTeamCommand
    {
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
