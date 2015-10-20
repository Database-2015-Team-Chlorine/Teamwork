namespace MediaMonitoringSystem.Data.Contracts
{
    using System.Collections.Generic;

    using MongoDB.Driver;

    using MediaMonitoringSystem.Models.MongoDb;

    public interface IMediaDistributorsMongoDbContext
    {
        ICollection<MediaDistributorModel> MediaDistributor { get; set; }

        MongoDatabase GetDatabase();
    }
}