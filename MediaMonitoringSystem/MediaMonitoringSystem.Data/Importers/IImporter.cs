namespace MediaMonitoringSystem.Data.Importers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IImporter
    {
        void ImportClientsFrom(string path);

        void ImportThemesFrom(string path);

        void ImportDepartmentsFrom(string path);

        void ImportEmployeesFrom(string path);

        void ImportMediaDistributorsFrom(string path);

        void ImportMediaPackagesFrom(string path);

        void ImportMediasFrom(string path);

        void ImportArticlesFrom(string path);
    }
}
