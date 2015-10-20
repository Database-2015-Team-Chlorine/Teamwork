namespace MediaMonitoringSystem.Data.MySql
{
    using System.Collections.Generic;
    using Models;
    using Telerik.OpenAccess.Metadata;
    using Telerik.OpenAccess.Metadata.Fluent;

    public partial class FluentModelMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var mediaMapping = new MappingConfiguration<MySqlMediaModel>();
            mediaMapping.MapType(m => new
            {
                Id = m.Id,
                Name = m.Name,
                Distributor = m.Distributor,
                TotalSells = m.TotalSells,
                Incomes = m.Incomes
            }).ToTable("Packages");
            mediaMapping.HasProperty(p => p.Id).IsIdentity(KeyGenerator.Autoinc);

            configurations.Add(mediaMapping);
            return configurations;
        }
    }
}
