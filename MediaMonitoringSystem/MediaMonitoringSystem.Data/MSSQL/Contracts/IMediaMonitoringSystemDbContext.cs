namespace MediaMonitoringSystem.Data.MSSQL.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using MediaMonitoringSystem.Models;
    using MediaMonitoringSystem.Models.MSSQL;

    public interface IMediaMonitoringSystemDbContext
    {
        IDbSet<Client> Clients { get; set; }

        IDbSet<Media> Medias { get; set; }

        IDbSet<Package> Packages { get; set; }

        IDbSet<Theme> Themes { get; set; }

        IDbSet<Article> Articles { get; set; }

        IDbSet<Department> Departments { get; set; }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<MediaDistributor> MediaDistributors { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
