namespace MediaMonitoringSystem.Data.Contracts
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using MediaMonitoringSystem.Models.Sqlite;

    public interface IMediaMonitoringPricingDbContext
    {
        IDbSet<Price> Pricing { get; set; }

        IDbSet<T> Set<T>() where T : class;
    }
}
