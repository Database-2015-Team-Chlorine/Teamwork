namespace MediaMonitoringSystem.Data.MongoDb
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Driver;

    using MediaMonitoringSystem.Models.Sql;
    using MediaMonitoringSystem.Models.MongoDb;
    using MediaMonitoringSystem.Models.Contracts;

    public class MediaDistributorsMongoData
    {
        private readonly MediaDistributorsMongoDbContext context;
        private readonly MongoDatabase db;
        private readonly MongoCollection<MediaDistributorModel> distributors;

        public MediaDistributorsMongoData()
        {
            this.context = new MediaDistributorsMongoDbContext();
            this.db = this.context.GetDatabase();
            this.distributors = this.db.GetCollection<MediaDistributorModel>("Distributors");
            Console.WriteLine("Mongo created!");
        }

        public void InsertToMongo(ICollection<MediaDistributorModel> distributorsToInsert)
        {
            this.distributors.InsertBatch(distributorsToInsert);
        }

        public IEnumerable<MediaDistributor> GetFromMongo()
        {
            var result = new List<MediaDistributor>();

            foreach (var distributor in this.distributors.FindAll())
            {
                var distributorSql = new MediaDistributor()
                {
                    Name = distributor.Name
                };

                foreach (var media in distributor.Medias)
                {
                    var mediaSql = new Media()
                    {
                        Name = media.Name,
                        PriceSubscriptionPerMonth = media.PriceSubscriptionPerMonth,
                        DepartmentId = 1,
                        Type = media.Type
                    };

                    distributorSql.Medias.Add(mediaSql);
                }

                result.Add(distributorSql);
            }

            return result;
        }
    }
}
