namespace MongoDbAndDesignPatternProject.DAL.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TeamCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
    }
}
