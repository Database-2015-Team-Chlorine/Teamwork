namespace MediaMonitoringSystem.Data.Contracts
{
    using MediaMonitoringSystem.Models.Sqlite;

    public interface IMediaMonitoringPricingData
    {
        IGenericRepository<Price> Prices { get; }
    }
}
