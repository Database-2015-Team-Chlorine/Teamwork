namespace MediaMonitoringSystem.Importers.Excel
{
    using MediaMonitoringSystem.Importers.Contracts;

    public class ExcelBulkImporter : IBulkImporter
    {
        private IArchiever archiever;
        private IImporter importer;
        private string[] paths;

        public ExcelBulkImporter(IArchiever archiever, IImporter importer, string[] paths)
        {
            this.archiever = archiever;
            this.importer = importer;
            this.paths = paths;
        }

        public void ImportAll()
        {
            string zipPath = this.paths[0];
            string extractedPath = this.paths[1];
            string filePath = this.paths[2];

            this.archiever.UnArchieve(zipPath, extractedPath);

            this.importer.ImportClientsFrom(filePath);
            this.importer.ImportThemesFrom(filePath);
            this.importer.ImportDepartmentsFrom(filePath);
            this.importer.ImportEmployeesFrom(filePath);
            this.importer.ImportMediaDistributorsFrom(filePath);
            this.importer.ImportMediaPackagesFrom(filePath);
            this.importer.ImportMediasFrom(filePath);
            this.importer.ImportArticlesFrom(filePath);
        }
    }
}