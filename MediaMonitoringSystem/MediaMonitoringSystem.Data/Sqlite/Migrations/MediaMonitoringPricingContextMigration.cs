namespace MediaMonitoringSystem.Data.Sqlite.Migrations
{
    using System.Data.Entity;
    using System.Linq;
    using MediaMonitoringSystem.Models.Sqlite;

    public class MediaMonitoringPricingContextMigration : DbContext
    {
        public static int RequiredDatabaseVersion = 1;

        public IDbSet<Price> Pricing { get; set; }

        public IDbSet<SchemaInfo> SchemaInfoes { get; set; }

        public void Initialize()
        {
            using (MediaMonitoringPricingContextMigration mediaPricingContext = new MediaMonitoringPricingContextMigration())
            {
                int currentVersion = 0;
                if (mediaPricingContext.SchemaInfoes.Count() > 0)
                {
                    currentVersion = mediaPricingContext.SchemaInfoes.Max(x => x.Version);
                }

                MediaMonitoringPricingContextHelper sqliteHelper = new MediaMonitoringPricingContextHelper();

                while (currentVersion < RequiredDatabaseVersion)
                {
                    currentVersion++;
                    foreach (string migration in sqliteHelper.Migrations[currentVersion])
                    {
                        mediaPricingContext.Database.ExecuteSqlCommand(migration);
                    }

                    mediaPricingContext.SchemaInfoes.Add(new SchemaInfo()
                    {
                        Version = currentVersion
                    });

                    mediaPricingContext.SaveChanges();
                }
            }
        }
    }
}
