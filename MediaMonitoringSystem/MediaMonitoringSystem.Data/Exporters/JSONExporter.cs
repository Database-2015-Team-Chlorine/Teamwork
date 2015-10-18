namespace MediaMonitoringSystem.Data.Exporters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    //In system.web.extentions
    using System.Web.Script.Serialization;

    public class JSONExporter : IExporter
    {
        public string Export(IList table)
        {
            //Just recieving a list and processing it to JSON

            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(table);
        }
    }
}
