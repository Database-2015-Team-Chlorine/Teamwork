namespace MediaMonitoringSystem.Data.Sqlite
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using MediaMonitoringSystem.Data.Contracts;
    using MediaMonitoringSystem.Models.Sqlite;

    public class MediaMonitoringPricingDbContext : DbContext, IMediaMonitoringPricingDbContext
    {
        public MediaMonitoringPricingDbContext()
            : base("MediaMonitoringPricing")
        {
        }

        public IDbSet<Price> Pricing { get; set; }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }
}
