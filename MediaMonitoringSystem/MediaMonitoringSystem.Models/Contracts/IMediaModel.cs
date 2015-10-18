namespace MediaMonitoringSystem.Models.Contracts
{
    public interface IMediaModel
    {
        string Name { get; }

        decimal PriceSubscriptionPerMonth { get; }
    }
}