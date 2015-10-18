namespace MediaMonitoringSystem.Data.Exporters
{
    using System.Collections;

    public interface IExporter
    {
        string Export(IList table);
    }
}
