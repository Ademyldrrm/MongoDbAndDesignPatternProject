namespace MongoDbAndDesignPatternProject.CQRSPattern.Commands
{
    public class UpdateTeamCommand
    {
        public string TeamID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
