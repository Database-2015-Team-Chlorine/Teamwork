namespace MediaMonitoringSystem.Data.Exporters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    public class XMLExporter : IExporter
    {

        //The IList must be processed, so it will be added as XElements after that you serialize it and return it as a string

        //XElement books =
        //   new XElement("books",
        //     new XElement("book",
        //       new XElement("author", "Don Box"),
        //       new XElement("title", "ASP.NET")));

        public string Export(IList input)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                xmlSerializer.Serialize(stringWriter, input);
                return stringWriter.ToString();
            }
        }
    }
}
