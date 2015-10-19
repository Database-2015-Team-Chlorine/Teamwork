namespace MediaMonitoringSystem.Data.MSSQL
{
    using System;
    using System.Collections.Generic;
    using MediaMonitoringSystem.Data.Contracts;
    using MediaMonitoringSystem.Data.MSSQL.Repositories;
    using MediaMonitoringSystem.Models.MSSQL;

    public class MediaMonitoringSystemData : IMediaMonitoringSystemData
    {
        private IMediaMonitoringSystemDbContext dbContext;
        private IDictionary<Type, object> repositories;

        public MediaMonitoringSystemData(IMediaMonitoringSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public MediaMonitoringSystemData()
            : this(new MediaMonitoringSystemDbContext())
        {
        }

        public IGenericRepository<Client> Clients
        {
            get
            {
                return this.GetRepository<Client>();
            }
        }

        public IGenericRepository<Media> Medias
        {
            get
            {
                return this.GetRepository<Media>();
            }
        }

        public IGenericRepository<Package> Packages
        {
            get
            {
                return this.GetRepository<Package>();
            }
        }

        public IGenericRepository<Theme> Themes
        {
            get
            {
                return this.GetRepository<Theme>();
            }
        }

        public IGenericRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IGenericRepository<Department> Departments
        {
            get
            {
                return this.GetRepository<Department>();
            }
        }

        public IGenericRepository<Employee> Employees
        {
            get
            {
                return this.GetRepository<Employee>();
            }
        }

        public IGenericRepository<MediaDistributor> MediaDistributors
        {
            get
            {
                return this.GetRepository<MediaDistributor>();
            }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.dbContext));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}