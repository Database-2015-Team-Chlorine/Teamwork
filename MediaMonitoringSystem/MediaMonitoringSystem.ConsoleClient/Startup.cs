namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using MediaMonitoringSystem.Data;
    using System.Data.Entity;
    using MediaMonitoringSystem.Models;
    using MediaMonitoringSystem.Data.MSSQL;
    using MediaMonitoringSystem.Data.MongoDb;
    using MediaMonitoringSystem.MongoDb.ConsoleClient;
    using MongoDB.Driver.Builders;

    public class Startup
    {
        public static void Main()
        {
            var db = new MediaMonitoringSystemData();

            var mds = db.MediaDistributors.All();

            foreach (var md in mds)
            {
                Console.WriteLine(md.Name);
            }
        }
    }
}