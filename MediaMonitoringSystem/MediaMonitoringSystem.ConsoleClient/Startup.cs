namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using MediaMonitoringSystem.Data.Importers;
    using MediaMonitoringSystem.Data.Importers.ExcelImporter;
    using MediaMonitoringSystem.Data.Importers.XmlImporter;
    using iTextSharp.text.pdf;
    using iTextSharp.text;
    using iTextSharp.text.pdf.collection;
    using MediaMonitoringSystem.Data.Archievers;
    using MediaMonitoringSystem.Data.Exporters;
    using MediaMonitoringSystem.Data.MSSQL;
    using System.IO;
    using Data.MySQL;
    using Data.MySQL.Models;
    using MediaMonitoringSystem.Models.MSSQL;
    using Newtonsoft.Json;
    using MediaMonitoringSystem.Models.PDF;

    public class Startup
    {
        public static void Main()
        {
            GetDataToCreatPdf();



            //var mongo = new MongoModel();
            //var distributors = mongo.GenerateDistributors(3);

            //mongo.InsertToMongo(distributors);
            //var distributorsToSql = mongo.GetFromMongo();

            //var db = new MediaMonitoringSystemDbContext();

            //foreach (var d in distributorsToSql)
            //{
            //    db.MediaDistributors.Add(d);
            //}

            //db.SaveChanges();

            ////// Try this to create the files in Debug folder
            //DemoExporters.RunMe();

            ////Test Archiver UNcommend to test it
            //IArchiever zipArchiver = new ZipArchiever();
            //string zipPath = "../../MOCK_DATA.zip";
            //string extractedPath = "../../Export/";
            //zipArchiver.UnArchieve(zipPath, extractedPath);


           
            //IArchiever zipArchiver = new ZipArchiever();
            //IImporter excelImporter = new ExcelImporter(new MediaMonitoringSystemDbContext());

            //string[] paths = new string[]{
            //    "../../MOCK_DATA.zip",
            //    "../../Export/",
            //    "../../Export/MOCK_DATA/MOCK_DATA.xls"
            //};

            //IBulkImporter bulkImporter = new ExcelBulkImporter(zipArchiver, excelImporter, paths);

            //bulkImporter.ImportAll();

            XmlArticlesImporter xmlImporter = new XmlArticlesImporter(new MediaMonitoringSystemDbContext());
            string path = "../../articles.xml";
            xmlImporter.ImportArticlesFrom(path);
            

        }

        private static void GetDataToCreatPdf()
        {
            var db = new MediaMonitoringSystemData();

            var groupsOfThemes =
                db.Themes
                    .All()
                    .Select(t => new MediaMonitoringSystem.Models.PDF.Theme
                            {
                                Name = t.Name,
                                Client = t.Client.Name,
                                CountMedias = t.Package.CountMedias,
                                StartDate = t.StartDate,
                                EndDate = t.EndDate,
                                Price = t.Package.PricePerMonth
                            })
                    .OrderBy(n => n.Name)
                    .GroupBy(gr => gr.StartDate)
                    .ToList();

            string pathForPdf = "../../../PDFs/Themes.pdf";

            Pdf.GeneratePdf(groupsOfThemes, pathForPdf);
        }
    }
}