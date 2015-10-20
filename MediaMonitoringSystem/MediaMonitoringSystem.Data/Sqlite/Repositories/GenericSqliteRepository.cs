namespace MediaMonitoringSystem.Data.Sqlite.Repositories
{
    using System.Data.Entity;
    using System.Linq;
    using MediaMonitoringSystem.Data.Contracts;

    public class GenericSqliteRepository<T> : IGenericRepository<T>
        where T : class
    {
        private IMediaMonitoringPricingDbContext dbContext;
        private IDbSet<T> set;

        public GenericSqliteRepository(IMediaMonitoringPricingDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.set = dbContext.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        public void Add(T entity)
        {
            this.set.Add(entity);
        }

        public void Update(T entity)
        {
            this.Delete(entity);
            this.Add(entity);
        }

        public void Delete(T entity)
        {
            this.set.Remove(entity);
        }

        public void Detach(T entity)
        {
        }
    }
}
