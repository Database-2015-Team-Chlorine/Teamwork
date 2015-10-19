namespace MediaMonitoringSystem.Data.Contracts
{
    using System.Collections.Generic;
    using MediaMonitoringSystem.MongoDb.ConsoleClient;
    using MongoDB.Driver;

    public interface IMediaDistributorsMongoDbContext
    {
        ICollection<MediaDistributorModel> MediaDistributor { get; set; }

        MongoDatabase GetDatabase();
    }
}