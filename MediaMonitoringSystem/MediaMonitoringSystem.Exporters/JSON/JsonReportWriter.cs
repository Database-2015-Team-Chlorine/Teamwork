namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using System.IO;
    using MediaMonitoringSystem.Data.Sql;
    using MediaMonitoringSystem.Exporters.Contracts;
    using Newtonsoft.Json;

    public class JsonReportWriter : IDataWriter
    {
        private const string PathForJsonFiles = "../../../ExportedFiles/JOSNs/";

        public void Generate()
        {
            var db = new MediaMonitoringSystemDbContext();

            var medias = db.Medias
                .OrderBy(m => m.Id)
                .Select(m => new
                {
                    Id = m.Id,
                    Name = m.Name,
                    Distributor = m.MediaDistributor.Name,
                    TotalSells = db.Packages.Where(p => p.Medias.Contains(m)).Count(),
                    //Incomes = db.Packages.Where(p => p.Medias.Contains(m)).Sum(p => p.PricePerMonth)
                })
                .ToList();

            if (!Directory.Exists(PathForJsonFiles))
            {
                Directory.CreateDirectory(PathForJsonFiles);
            }

            foreach (var media in medias)
            {
                var serializedMedia = JsonConvert.SerializeObject(media);

                using (var writer = new StreamWriter(PathForJsonFiles + "/" + media.Id + ".json", false))
                {
                    writer.Write(JsonConvert.SerializeObject(serializedMedia, Formatting.Indented));
                }
            }
        }
    }
}