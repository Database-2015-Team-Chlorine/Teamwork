namespace MediaMonitoringSystem.Data.Contracts
{
    using MediaMonitoringSystem.Models;
    using MediaMonitoringSystem.Models.MSSQL;

    public interface IMediaMonitoringSystemData
    {
        IGenericRepository<Client> Clients { get; }

        IGenericRepository<Media> Medias { get; }

        IGenericRepository<Package> Packages { get; }

        IGenericRepository<Theme> Themes { get; }

        IGenericRepository<Article> Articles { get; }

        IGenericRepository<Department> Departments { get; }

        IGenericRepository<Employee> Employees { get; }

        IGenericRepository<MediaDistributor> MediaDistributors { get; }
    }
}
