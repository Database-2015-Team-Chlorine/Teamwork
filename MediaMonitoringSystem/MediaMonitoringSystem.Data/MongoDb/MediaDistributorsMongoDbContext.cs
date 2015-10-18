namespace MediaMonitoringSystem.Data.MongoDb
{    
    using MongoDB.Driver;

    public class MediaDistributorsMongoDbContext
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "MediaDistributors";

        public MongoDatabase GetDatabase()
        {
            MongoClient mongoClient = new MongoClient(DatabaseHost);
            MongoServer server = mongoClient.GetServer();
            MongoDatabase db = server.GetDatabase(DatabaseName);
            return db;
        }
    }
}
