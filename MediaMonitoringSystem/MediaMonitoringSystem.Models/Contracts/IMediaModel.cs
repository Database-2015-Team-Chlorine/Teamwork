namespace MediaMonitoringSystem.Models.MSSQL.Contracts
{
    public interface IMediaModel
    {
        string Name { get; }

        MediaType Type { get; }

        decimal PriceSubscriptionPerMonth { get; }
    }
}