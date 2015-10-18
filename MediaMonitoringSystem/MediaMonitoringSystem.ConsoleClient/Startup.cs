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
    using System.Collections.Generic;
    using MediaMonitoringSystem.Models.Contracts;
    using MediaMonitoringSystem.Models.MSSQL;
    using MediaMonitoringSystem.Models.MSSQL.Contracts;
    using MediaMonitoringSystem.Data.Exporters;

    public class Startup
    {
        public static void Main()
        {
            var mongo = new MongoModel();
            var distributors = mongo.GenerateDistributors(3);
            mongo.InsertToMongo(distributors);

            var distributorsToSql = mongo.GetFromMongo();
            Console.WriteLine(distributorsToSql);

            var db = new MediaMonitoringSystemData();

            foreach (var d in distributorsToSql)
            {
                //throw new Exeption dont know why????
                //db.MediaDistributors.Add(d);
            }

           //Try this to create the files in Debug folder

           //DemoExporters.RunMe();

        }
    }
}