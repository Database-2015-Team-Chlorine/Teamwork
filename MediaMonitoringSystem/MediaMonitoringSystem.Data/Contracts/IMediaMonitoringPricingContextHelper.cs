namespace MediaMonitoringSystem.Data.Contracts
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IMediaMonitoringPricingContextHelper
    {
        Dictionary<int, ICollection> Migrations { get; set; }
    }
}