namespace MediaMonitoringSystem.ConsoleClient
{
    using Data.Migrations;
    using MediaMonitoringSystem.Data;
    using System.Data.Entity;

    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediaMonitoringSystemDbContext, Configuration>());
            var db = new MediaMonitoringSystemDbContext();
        }
    }
}