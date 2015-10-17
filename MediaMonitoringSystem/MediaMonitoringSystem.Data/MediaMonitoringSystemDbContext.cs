namespace MediaMonitoringSystem.Data
{
    using System.Data.Entity;

    using MediaMonitoringSystem.Models;

    public class MediaMonitoringSystemDbContext : DbContext
    {
        public MediaMonitoringSystemDbContext()
            : base("MediaMonitoringSystem")
        {
        }

        public DbSet<Client> Clients { get; set; }
        
        public DbSet<Media> Medias { get; set; }
        
        public DbSet<Package> Packages { get; set; }

        public DbSet<Theme> Themes { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<MediaDistributor> MediaDistributors { get; set; }
    }
}
