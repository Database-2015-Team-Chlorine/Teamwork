namespace MediaMonitoringSystem.Data.MongoDb
{    
    using MongoDB.Driver;

    public class MediaDistributorsMongoDbContext
    {
        private const string DatabaseHost = "mongodb://127.0.0.1";
        private const string DatabaseName = "MediaDistributors";

        public MongoDatabase GetDatabase()
        {
            MongoClient mongoClient = new MongoClient(DatabaseHost);
            MongoServer server = mongoClient.GetServer();
            MongoDatabase db = server.GetDatabase(DatabaseName);
            return db;
        }
    }
}
