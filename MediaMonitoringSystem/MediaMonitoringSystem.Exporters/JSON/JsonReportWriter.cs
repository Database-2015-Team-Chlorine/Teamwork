namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using MediaMonitoringSystem.Data.Sql;
    using MediaMonitoringSystem.Exporters.Contracts;
    using Newtonsoft.Json;

    public class JsonReportWriter : IDataWriter
    {
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
                    Incomes = db.Packages.Where(p => p.Medias.Contains(m)).Sum(p => p.PricePerMonth)
                })
                .ToList();

            foreach (var media in medias)
            {
                var serializedMedia = JsonConvert.SerializeObject(media);
                Console.WriteLine(serializedMedia);
            }
        }
    }
}