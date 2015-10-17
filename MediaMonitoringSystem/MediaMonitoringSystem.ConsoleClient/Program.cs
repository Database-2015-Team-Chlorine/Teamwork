namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using MediaMonitoringSystem.Data;
    using System.Data.Entity;
    using MediaMonitoringSystem.Models;
    using MediaMonitoringSystem.Data.Migrations;

    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediaMonitoringSystemDbContext, Configuration>());

            var db = new MediaMonitoringSystemDbContext();

            var pesho = new MediaDistributor
                {
                    Name = "Na pesho mediite"
                };

            db.MediaDistributors.Add(pesho);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!!!!!!!!!!!!");
                Console.WriteLine((ex as System.Data.Entity.Validation.DbEntityValidationException).EntityValidationErrors.ToList()[0].ValidationErrors.ToList()[0].ErrorMessage);
            }
        }
    }
}