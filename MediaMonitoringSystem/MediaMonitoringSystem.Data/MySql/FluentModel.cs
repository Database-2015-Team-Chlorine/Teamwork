namespace MediaMonitoringSystem.Data.MySQL
{
    using System.Linq;
    using Models.MSSQL;
    using Telerik.OpenAccess;
    using Telerik.OpenAccess.Metadata;

    public partial class FluentModel : OpenAccessContext
    {
        private static string connectionStringName = @"connectionId";

        private static BackendConfiguration backend = GetBackendConfiguration();
        private static MetadataSource metadataSource = new FluentModelMetadataSource();

        public FluentModel()
            : base(connectionStringName, backend, metadataSource)
        { }

        public IQueryable<Package> Customers
        {
            get
            {
                return this.GetAll<Package>();
            }
        }

        public static BackendConfiguration GetBackendConfiguration()
        {
            BackendConfiguration backend = new BackendConfiguration();
            backend.Backend = "MySQL";
            backend.ProviderName = "System.Data.SqlClient";

            return backend;
        }
    }
}