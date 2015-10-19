using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaMonitoringSystem.Data.MSSQL;
using Newtonsoft.Json;

namespace MediaMonitoringSystem.ConsoleClient
{
    class ExportJson
    {
        public void GetJson()
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
