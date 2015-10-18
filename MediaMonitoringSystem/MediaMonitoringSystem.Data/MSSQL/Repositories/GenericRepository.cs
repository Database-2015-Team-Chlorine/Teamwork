namespace MediaMonitoringSystem.Data.MSSQL.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using MediaMonitoringSystem.Data.MSSQL.Contracts;

    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private IMediaMonitoringSystemDbContext dbContext;
        private IDbSet<T> set;

        public GenericRepository(IMediaMonitoringSystemDbContext dbContext)
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
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public void Detach(T entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Detached;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}