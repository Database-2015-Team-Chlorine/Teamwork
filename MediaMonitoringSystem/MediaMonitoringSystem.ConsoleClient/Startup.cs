namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using Data.MySQL;
    using Data.MySQL.Models;
    using MediaMonitoringSystem.Data.Archievers;
    using MediaMonitoringSystem.Data.MSSQL;
    using Telerik.OpenAccess;

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

            //Test Archiver UNcommend to test it

            //IArchiever zipArchiver = new ZipArchiever();
            //string zipPath = "../../MOCK_DATA.zip";
            //string extractedPath = "../../Export/";
            //zipArchiver.UnArchieve(zipPath, extractedPath);

            UpdateDatabase();

            using (FluentModel dbContext = new FluentModel())
            {
                var media = new MySqlMediaModel
                {
                    Name = "Sofia news",
                    Distributor = "Pesho",
                    TotalSells = 10,
                    Incomes = 153
                };

                dbContext.Add(media);
                dbContext.SaveChanges();
            }
        }

        private static void UpdateDatabase()
        {
            using (var context = new FluentModel())
            {
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
            }
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;
            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }

    }
}