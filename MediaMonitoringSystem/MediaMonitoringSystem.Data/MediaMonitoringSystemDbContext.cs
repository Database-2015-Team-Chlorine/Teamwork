namespace MediaMonitoringSystem.Data
{
    using MediaMonitoringSystem.Models;
    using System.Data.Entity;

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

        public DbSet<MediaDistributor> MediaDistributors { get; set; }
    }
}