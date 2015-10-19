namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using MediaMonitoringSystem.Data.Archievers;
    using MediaMonitoringSystem.Data.MSSQL;

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
        }
    }
}