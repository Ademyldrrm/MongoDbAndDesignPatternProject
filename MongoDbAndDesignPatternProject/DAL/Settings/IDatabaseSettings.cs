﻿namespace MongoDbAndDesignPatternProject.DAL.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TeamCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string ServiceCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string AboutInformtionCollectionName { get; set; }
        
        
    }
}
