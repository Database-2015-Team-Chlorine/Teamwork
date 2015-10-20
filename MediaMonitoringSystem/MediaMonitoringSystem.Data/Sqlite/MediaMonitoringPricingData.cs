namespace MediaMonitoringSystem.Data.Sqlite
{
    using System;
    using System.Collections.Generic;
    using MediaMonitoringSystem.Data.Contracts;
    using MediaMonitoringSystem.Data.Sqlite.Repositories;
    using MediaMonitoringSystem.Models.Sqlite;

    public class MediaMonitoringPricingData : IMediaMonitoringPricingData
    {
        private IMediaMonitoringPricingDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public MediaMonitoringPricingData(IMediaMonitoringPricingDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public MediaMonitoringPricingData()
            : this(new MediaMonitoringPricingDbContext())
        {
        }

        public IGenericRepository<Price> Prices
        {
            get 
            {
                return this.GetRepository<Price>();
            }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericSqliteRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.dbContext));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
