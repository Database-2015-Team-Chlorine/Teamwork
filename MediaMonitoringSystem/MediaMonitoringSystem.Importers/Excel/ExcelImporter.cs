namespace MediaMonitoringSystem.Importers.Excel
{
    using System;
    using System.Data.OleDb;
    using MediaMonitoringSystem.Data.Contracts;
    using MediaMonitoringSystem.Importers.Contracts;
    using MediaMonitoringSystem.Models.Contracts;
    using MediaMonitoringSystem.Models.Sql;

    public class ExcelImporter : IImporter
    {
        private readonly IMediaMonitoringSystemDbContext db;

        public ExcelImporter(IMediaMonitoringSystemDbContext context)
        {
            this.db = context;
        }

        public void ImportClientsFrom(string path)
        {
            string con =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
            @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [clients$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string name = dr[0].ToString();

                        this.db.Clients.Add(new Client
                        {
                            Name = name
                        });
                    }
                    this.db.SaveChanges();
                    Console.WriteLine("Clients added!");
                }
            }
        }

        public void ImportThemesFrom(string path)
        {
            string con =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
            @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [themes$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string name = dr[0].ToString();
                        DateTime startDate = Convert.ToDateTime(dr[1]);
                        DateTime endDate = Convert.ToDateTime(dr[2]);
                        int clientID = int.Parse(dr[3].ToString());
                        int packageID = int.Parse(dr[4].ToString());

                        this.db.Themes.Add(new Theme
                        {
                            Name = name,
                            StartDate = startDate,
                            EndDate = endDate,
                            ClientId = clientID,
                            PackageId = packageID
                        });
                    }
                    this.db.SaveChanges();
                    Console.WriteLine("Themes added!");
                }
            }
        }

        public void ImportDepartmentsFrom(string path)
        {
            string con =
           @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
           @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [departments$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string name = dr[0].ToString();

                        this.db.Departments.Add(new Department
                        {
                            Name = name
                        });

                    }
                    this.db.SaveChanges();
                    Console.WriteLine("Departments added!");
                }
            }
        }

        public void ImportEmployeesFrom(string path)
        {
            string con =
           @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
           @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [employees$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string name = dr[0].ToString();
                        int depId = int.Parse(dr[1].ToString());

                        this.db.Employees.Add(new Employee
                        {
                            Name = name,
                            DepartmentId = depId
                        });
                    }
                    Console.WriteLine("Employees added!");
                    this.db.SaveChanges();
                }
            }
        }

        public void ImportMediaDistributorsFrom(string path)
        {
            string con =
           @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
           @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [mediaDist$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string name = dr[0].ToString();

                        this.db.MediaDistributors.Add(new MediaDistributor
                        {
                            Name = name,
                        });
                    }
                    Console.WriteLine("Media distributores added");
                    this.db.SaveChanges();
                }
            }
        }

        public void ImportMediaPackagesFrom(string path)
        {
            string con =
           @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
           @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [mediaPacks$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int numberOfMedias = int.Parse(dr[0].ToString());
                        decimal price = decimal.Parse(dr[1].ToString());

                        this.db.Packages.Add(new Package
                        {
                            CountMedias = numberOfMedias,
                            PricePerMonth = price
                        });
                    }
                    this.db.SaveChanges();
                    Console.WriteLine("Packages added!");
                }
            }
        }

        public void ImportMediasFrom(string path)
        {
            string con =
           @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
           @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [medias$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int mediaType = int.Parse(dr[0].ToString());
                        var name = dr[1].ToString();
                        int distributorId = int.Parse(dr[2].ToString());
                        int departmentId = int.Parse(dr[3].ToString());
                        decimal price = decimal.Parse(dr[4].ToString());

                        this.db.Medias.Add(new Media
                        {
                            Type = (MediaType)mediaType,
                            Name = name,
                            MediaDistributorId = distributorId,
                            DepartmentId = departmentId,
                            PriceSubscriptionPerMonth = price
                        });
                    }
                    Console.WriteLine("Medias added!");
                    this.db.SaveChanges();
                }
            }
        }

        public void ImportArticlesFrom(string path)
        {
            string con =
            @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" +
            @"Extended Properties='Excel 8.0;HDR=Yes;'";

            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [dataArticles$]", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string title = dr[0].ToString();
                        string content = dr[1].ToString();
                        DateTime date = Convert.ToDateTime(dr[2]);

                        int mediaId = int.Parse(dr[4].ToString());

                        this.db.Articles.Add(new Article
                        {
                            Title = title,
                            Content = content,
                            PublishedOn = date,
                            MediaId = mediaId
                        });
                    }
                    Console.WriteLine("Articles added!");
                    this.db.SaveChanges();
                }
            }
        }
    }
}