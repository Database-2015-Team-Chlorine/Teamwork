namespace MediaMonitoringSystem.ConsoleClient
{
    using System.Linq;

    using MediaMonitoringSystem.Data.MongoDb;
    using MediaMonitoringSystem.Data.Sql;
    using MediaMonitoringSystem.Exporters.Pdf;
    using MediaMonitoringSystem.Generator;
    using MediaMonitoringSystem.Importers.Archive;
    using MediaMonitoringSystem.Importers.Contracts;
    using MediaMonitoringSystem.Importers.Excel;

    public class Startup
    {
        public static void Main()
        {
            // Creating MongoDb database.
            var dbMongoDb = new MediaDistributorsMongoData();


            // Generating distributors.
            var genedartor = new DataGenerator();
            var generatedDistributors = genedartor.GenerateDistributors(3);


            // Inserting to MongoDb
            dbMongoDb.InsertToMongo(generatedDistributors);
            var distributorsToSql = dbMongoDb.GetFromMongo();


            // Creating and insert to SQL Server
            var dbSql = new MediaMonitoringSystemDbContext();
            foreach (var distributor in distributorsToSql)
            {
                dbSql.MediaDistributors.Add(distributor);
            }
            dbSql.SaveChanges();


            // Extracting zip
            IArchiever zipArchiver = new ZipArchiever();
            string zipPath = "../../MOCK_DATA.zip";
            string extractedPath = "../../Export/";
            zipArchiver.UnArchieve(zipPath, extractedPath);

            IImporter excelImporter = new ExcelImporter(new MediaMonitoringSystemDbContext());

            string[] paths = new string[]
            {
                "../../MOCK_DATA.zip",
                "../../Export/",
                "../../Export/MOCK_DATA/MOCK_DATA.xls"
            };


            // Importing data from excel
            IBulkImporter bulkImporter = new ExcelBulkImporter(zipArchiver, excelImporter, paths);
            bulkImporter.ImportAll();


            // Creating PDF
            var pdfWriter = new PdfReportWriter();
            pdfWriter.Generate();
        }
    }
}