namespace MediaMonitoringSystem.Data.Sql.Migrations
{
    using System.Data.Entity.Migrations;

    using MediaMonitoringSystem.Models.Sql;

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

            var departament = new Department
            {
                Name = "Departament"
            };

            context.Departments.Add(departament);
            context.MediaDistributors.Add(pesho);
        }
    }
}