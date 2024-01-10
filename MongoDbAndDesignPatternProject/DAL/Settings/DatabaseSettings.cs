namespace MongoDbAndDesignPatternProject.DAL.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TeamCollectionName { get; set; }
    }
}
