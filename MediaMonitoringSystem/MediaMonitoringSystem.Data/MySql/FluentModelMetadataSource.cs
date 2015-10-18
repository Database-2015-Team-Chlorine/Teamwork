namespace MediaMonitoringSystem.Data.MySQL
{
    using System.Collections.Generic;
    using Models.MSSQL;
    using Telerik.OpenAccess.Metadata.Fluent;

    public partial class FluentModelMetadataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations =
                new List<MappingConfiguration>();

            var packageMapping = new MappingConfiguration<Package>();
            packageMapping.MapType(package => new
            {
                Id = package.Id,
                CountMedias = package.CountMedias,
                PricePerMonth = package.PricePerMonth
            }).ToTable("Packages");

            packageMapping.HasProperty(p => p.Id).IsIdentity();

            configurations.Add(packageMapping);

            return configurations;
        }
    }
}
