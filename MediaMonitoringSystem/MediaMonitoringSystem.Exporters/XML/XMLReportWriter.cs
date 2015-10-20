namespace MediaMonitoringSystem.Exporters.XML
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using MediaMonitoringSystem.Data.Sql;
    using MediaMonitoringSystem.Exporters.Contracts;

    public class XMLReportWriter : IDataWriter
    {
        public void Generate()
        {
            var db = new MediaMonitoringSystemDbContext();

            var clients = db.Clients.Select(c => new
                {
                    Name = c.Name,
                    Themes = c.Themes.Select(t => new 
                    {
                        Start = t.StartDate,
                        End = t.EndDate,
                        Theme = t.Name,
                        Packages = t.Package.Medias.Select(m => new
                        {
                            Media = m.Name,
                            Articles = m.Articles.Select(a => new
                            {
                                Title = a.Title,
                                PublishedOn = a.PublishedOn,
                                Content = a.Content
                            })
                            .OrderBy(a => a.PublishedOn)
                        })
                        .OrderBy(m => m.Media)
                    })
                    .OrderBy(t => t.Start)
                })
                .ToList();

            foreach (var client in clients)
            {
                string fileName = "../../client-" + client.Name + ".xml";
                Encoding encoding = Encoding.GetEncoding("windows-1251");

                var xmlNode =
                    new XElement("client",
                         new XAttribute("name", client.Name),
                         new XElement("themes",
                             new XElement("theme", client.Name)
                         )
                     );

                xmlNode.Save(fileName);
            }
        }
    }
}