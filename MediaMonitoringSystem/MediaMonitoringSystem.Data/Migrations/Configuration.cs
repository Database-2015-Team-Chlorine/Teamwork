namespace MediaMonitoringSystem.Data.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<MediaMonitoringSystem.Data.MediaMonitoringSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MediaMonitoringSystem.Data.MediaMonitoringSystemDbContext";
        }

        protected override void Seed(MediaMonitoringSystem.Data.MediaMonitoringSystemDbContext context)
        {
            var mtg = new MediaDistributor
            {
                Name = "MTG"
            };

            var novaTv = new Media
            {
                Name = "Nova TV",
                Type = MediaType.TV,
                MediaDistributor = mtg,
                PriceSubscriptionPerMonth = 32.0M
            };

            var novaSport = new Media
            {
                Name = "Nova sport TV",
                Type = MediaType.TV,
                MediaDistributor = mtg,
                PriceSubscriptionPerMonth = 35.0M
            };

            context.MediaDistributors.AddOrUpdate(
                md => md.Name,
                mtg);

            context.Medias.AddOrUpdate(
                m => m.Name,
                novaTv,
                novaSport
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}