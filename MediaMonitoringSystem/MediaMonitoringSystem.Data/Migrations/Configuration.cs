namespace MediaMonitoringSystem.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<MediaMonitoringSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MediaMonitoringSystem.Data.MediaMonitoringSystemDbContext";
        }

        protected override void Seed(MediaMonitoringSystemDbContext context)
        {
        }
    }
}