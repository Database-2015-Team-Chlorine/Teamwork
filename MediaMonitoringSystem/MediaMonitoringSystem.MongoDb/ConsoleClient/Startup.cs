namespace MediaMonitoringSystem.MongoDb.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    
    using MongoDB.Driver;

    public class Startup
    {
        const string DatabaseHost = "mongodb://127.0.0.1";
        const string DatabaseName = "MediaDistributors";

        public static void Main()
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);

            var distributorsCollection = db.GetCollection<MediaDistributorModel>("Distributors");

            var distributorsToAdd = GetDistributors();

            distributorsCollection.InsertBatch(distributorsToAdd);

            MongoCursor<MediaDistributorModel> distributors = distributorsCollection.FindAll();

            foreach (var item in distributors)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static MongoDatabase GetDatabase(string name, string fromHost)
        {
            MongoClient mongoClient = new MongoClient(fromHost);
            MongoServer server = mongoClient.GetServer();
            MongoDatabase db = server.GetDatabase(name);
            return db;
        }

        private static ICollection<MediaDistributorModel> GetDistributors()
        {
            MediaDistributorModel[] distributors = 
                {
                    new MediaDistributorModel() 
                    {
                        Name = "MTG", Medias = new List<MediaModel>()
                        {
                            new MediaModel() { Name = "Nova tv", PriceSubscriptionPerMonth = 23.5M },
                            new MediaModel() { Name = "Nova Sport", PriceSubscriptionPerMonth = 44.5M },
                            new MediaModel() { Name = "Diema", PriceSubscriptionPerMonth = 100.0M }
                        }
                    },
                    new MediaDistributorModel() 
                    {
                        Name = "National Media Distributor", Medias = new List<MediaModel>()
                        {
                            new MediaModel() { Name = "BNR", PriceSubscriptionPerMonth = 20.0M },
                            new MediaModel() { Name = "BNT", PriceSubscriptionPerMonth = 33.5M },
                            new MediaModel() { Name = "24 chasa", PriceSubscriptionPerMonth = 20.0M }
                        }
                    },
                    new MediaDistributorModel() 
                    {
                        Name = "Na pesho mediite", Medias = new List<MediaModel>()
                        {
                            new MediaModel() { Name = "vestnik 18+", PriceSubscriptionPerMonth = 23000.5M },
                            new MediaModel() { Name = "Samo za vuzrastni TV", PriceSubscriptionPerMonth = 44000.5M },
                            new MediaModel() { Name = "Playboy Magazine", PriceSubscriptionPerMonth = 100000.0M }
                        }
                    }
                };

            return distributors;
        }
    }
}
