namespace MediaMonitoringSystem.Data.Exporters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    using MediaMonitoringSystem.Data.MSSQL;

    public class DemoExporters
    {
        public static void RunMe()
        {
            //I'm using the telerik DB for testing. Our DB can also be used!
            var db = new MediaMonitoringSystemData();

            //Geting the desired things from the DB
            var projects = db.MediaDistributors.All().Select(md => md.Name).ToList();

            //Exporters
            var jsonExporter = new JSONExporter();

            //should recieve a list
            var xmlExporter = new XMLExporter();

            //Getting result strings
            var resultFromJSON = jsonExporter.Export(projects);
            var resultFromXML = xmlExporter.Export(projects);


            //writers output the files in porject/bin/Debug/{name of file}
            //Writing it in .json file, the file is correctly outputed.
            using (var sw = new StreamWriter("JSONResult.json"))
            {
                sw.Write(resultFromJSON);
            }
            using (var sw = new StreamWriter("XMLResult.xml"))
            {
                //using XElement you can add indentions, which will work correctly when writen, but the string must be in that format.
                XElement books =
            new XElement("books",
              new XElement("book",
                new XElement("author", "Don Box"),
                new XElement("title", "ASP.NET")));

                Console.WriteLine(books);

                sw.Write(books);

                //sw.Write(resultFromXML);
            }
        }
    }
}