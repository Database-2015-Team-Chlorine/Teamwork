namespace MediaMonitoringSystem.Importers.Contracts
{
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