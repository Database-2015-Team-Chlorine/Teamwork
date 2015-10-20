namespace MediaMonitoringSystem.Data.Sql
{
    using System;
    using System.Data.Entity;
    using MediaMonitoringSystem.Data.Contracts;
    using MediaMonitoringSystem.Data.Sql.Migrations;
    using MediaMonitoringSystem.Models.Sql;

    public class MediaMonitoringSystemDbContext : DbContext, IMediaMonitoringSystemDbContext
    {
        public MediaMonitoringSystemDbContext()
            : base("MediaMonitoringSystem")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediaMonitoringSystemDbContext, Configuration>());
<<<<<<< HEAD
            Console.WriteLine("SQL Server created!");
=======
>>>>>>> e1c871f4a51ce55ee53ae24534264957938a56bb
        }

        public IDbSet<Client> Clients { get; set; }

        public IDbSet<Media> Medias { get; set; }

        public IDbSet<Package> Packages { get; set; }

        public IDbSet<Theme> Themes { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public IDbSet<Department> Departments { get; set; }

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<MediaDistributor> MediaDistributors { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}