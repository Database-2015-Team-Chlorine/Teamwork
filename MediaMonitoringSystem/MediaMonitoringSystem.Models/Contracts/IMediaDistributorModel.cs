namespace MediaMonitoringSystem.Models.Contracts
{
    using System.Collections.Generic;

    public interface IMediaDistributorModel
    {
        string Name { get; set; }

        ICollection<IMediaModel> Medias { get; set; }
    }
}
