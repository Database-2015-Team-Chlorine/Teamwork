namespace MediaMonitoringSystem.ConsoleClient
{
    using System.Linq;
    using MediaMonitoringSystem.Data.MSSQL;
    using MediaMonitoringSystem.Exporters.Pdf;
    using MediaMonitoringSystem.Importers.Archive;
    using MediaMonitoringSystem.Importers.Contracts;
    using MediaMonitoringSystem.Importers.Excel;

    public class Startup
    {
        public static void Main()
        {
            var mongo = new MongoModel();
            var distributors = mongo.GenerateDistributors(3);

            mongo.InsertToMongo(distributors);
            var distributorsToSql = mongo.GetFromMongo();

            var db = new MediaMonitoringSystemDbContext();

            foreach (var d in distributorsToSql)
            {
                db.MediaDistributors.Add(d);
            }

            db.SaveChanges();

            //// Try this to create the files in Debug folder
           // DemoExporters.RunMe();

            //Test Archiver UNcommend to test it
            IArchiever zipArchiver = new ZipArchiever();
            string zipPath = "../../MOCK_DATA.zip";
            string extractedPath = "../../Export/";
            zipArchiver.UnArchieve(zipPath, extractedPath);

            var pdfWriter = new PdfReportWriter();
            pdfWriter.Generate();
           // GetDataToCreatPdf();
            
            // TODO: Throws exceptiopn adding articles
            IArchiever zipArchiver2 = new ZipArchiever();
            IImporter excelImporter = new ExcelImporter(new MediaMonitoringSystemDbContext());

            string[] paths = new string[]
            {
                "../../MOCK_DATA.zip",
                "../../Export/",
                "../../Export/MOCK_DATA/MOCK_DATA.xls"
            };

            IBulkImporter bulkImporter = new ExcelBulkImporter(zipArchiver2, excelImporter, paths);

            bulkImporter.ImportAll();
        }
    }
}