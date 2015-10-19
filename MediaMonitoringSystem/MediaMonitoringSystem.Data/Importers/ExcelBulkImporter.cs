namespace MediaMonitoringSystem.Data.Importers
{
    using MediaMonitoringSystem.Data.Archievers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Threading.Tasks;
    using MediaMonitoringSystem.Data.MSSQL.Contracts;

    public class ExcelBulkImporter : IBulkImporter
    {
        private IArchiever archiever;
        private IImporter importer;
        private string[] paths;
        public ExcelBulkImporter (IArchiever archiever, IImporter importer, string [] paths)
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

            importer.ImportClientsFrom(filePath);
            importer.ImportThemesFrom(filePath);
            importer.ImportDepartmentsFrom(filePath);
            importer.ImportEmployeesFrom(filePath);
            importer.ImportMediaDistributorsFrom(filePath);
            importer.ImportMediaPackagesFrom(filePath);
            importer.ImportMediasFrom(filePath);
            importer.ImportArticlesFrom(filePath);           
        }
    }
}
