namespace MediaMonitoringSystem.Data.Sqlite.Migrations
{
    using System.Collections;
    using System.Collections.Generic;
    using MediaMonitoringSystem.Data.Contracts;

    public class MediaMonitoringPricingContextHelper : IMediaMonitoringPricingContextHelper
    {
        public MediaMonitoringPricingContextHelper()
        {
            this.Migrations = new Dictionary<int, ICollection>();
            this.MigrationVersion();
        }

        public Dictionary<int, ICollection> Migrations { get; set; }

        private void MigrationVersion()
        {
            var steps = new List<string>();

            steps.Add("CREATE TABLE \"Pricing\" (\"Id\" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , \"PercentageCharging\" MONEY)");

            Migrations.Add(1, steps);
        }
    }
}
