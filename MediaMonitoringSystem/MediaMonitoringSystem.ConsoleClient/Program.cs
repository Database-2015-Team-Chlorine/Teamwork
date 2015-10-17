namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using MediaMonitoringSystem.Data;
    using System.Data.Entity;

    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediaMonitoringSystemDbContext, Configuration>());
            var db = new MediaMonitoringSystemDbContext();

            var mtg = new MediaDistributor
                {
                    Name = "MTG"
                };

            db.MediaDistributors.Add(mtg);

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

            db.Medias.Add(novaTv);
            db.Medias.Add(novaSport);

            db.SaveChanges();
        }
    }
}