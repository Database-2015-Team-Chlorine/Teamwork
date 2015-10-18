namespace MediaMonitoringSystem.Data.MSSQL.Migrations
{
    using System.Data.Entity.Migrations;
    using MediaMonitoringSystem.Models.MSSQL;

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
            var pesho = new MediaDistributor
            {
                Name = "DbMedia5"
            };

            context.MediaDistributors.Add(pesho);
        }
    }
}