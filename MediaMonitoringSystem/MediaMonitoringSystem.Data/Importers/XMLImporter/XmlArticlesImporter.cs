using MediaMonitoringSystem.Data.MSSQL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MediaMonitoringSystem.Data.Importers.XmlImporter
{
    using System.Xml.Linq;
    using MediaMonitoringSystem.Models.MSSQL;

    public class XmlArticlesImporter
    {
        private readonly IMediaMonitoringSystemDbContext db;

        public XmlArticlesImporter(IMediaMonitoringSystemDbContext context)
        {
            this.db = context;
        }

        public void ImportArticlesFrom(string path)
        {
            XDocument xmlDoc = XDocument.Load(path);

            var articles =
            from article in xmlDoc.Descendants("article")
            select new
            {
                MediaID = article.Attribute("mediaID").Value,
                Title = article.Element("title").Value,
                Content = article.Element("content").Value,
                Date = article.Element("date").Value
            };

            foreach (var article in articles)
            {
                DateTime date = Convert.ToDateTime(article.Date);
                Console.WriteLine(date);
                this.db.Articles.Add(new Article
                        {
                            Title = article.Title.ToString(),
                            Content = article.Content.ToString(),
                            PublishedOn = date,
                            MediaId = int.Parse(article.MediaID)
                        });
                //this.db.SaveChanges();
                Console.WriteLine("importing " + article.Title);
            }

        }
    }
}
