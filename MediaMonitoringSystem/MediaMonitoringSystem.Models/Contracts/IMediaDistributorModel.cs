namespace MediaMonitoringSystem.Models.Contracts
{
    using System.Collections.Generic;
    using MediaMonitoringSystem.MongoDb.ConsoleClient;

    public interface IMediaDistributorModel
    {
        string Name { get; set; }

        ICollection<MediaModel> Medias { get; set; }
    }
}
