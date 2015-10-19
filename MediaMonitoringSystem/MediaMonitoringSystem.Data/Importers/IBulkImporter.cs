namespace MediaMonitoringSystem.Data.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBulkImporter
    {
        void ImportAll();
    }
}
