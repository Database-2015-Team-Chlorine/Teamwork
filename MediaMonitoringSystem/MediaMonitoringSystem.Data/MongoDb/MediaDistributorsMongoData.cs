namespace MediaMonitoringSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MediaMonitoringSystem.Data.Contracts;
    using MediaMonitoringSystem.Data.MongoDb;
    using MediaMonitoringSystem.Models.MSSQL;
    using MediaMonitoringSystem.Models.MSSQL.Contracts;
    using MediaMonitoringSystem.MongoDb.ConsoleClient;
    using MongoDB.Driver;

    public class MongoModel
    {
        private readonly MediaDistributorsMongoDbContext context;
        private readonly MongoDatabase db;
        private readonly MongoCollection<MediaDistributorModel> distributors;

        public MongoModel()
        {
            this.context = new MediaDistributorsMongoDbContext();
            this.db = this.context.GetDatabase();
            this.distributors = this.db.GetCollection<MediaDistributorModel>("Distributors");
        }

        public ICollection<MediaDistributorModel> GenerateDistributors(int count)
        {
            var distributors = new List<MediaDistributorModel>();

            for (int i = 0; i < count; i++)
            {
                var media = new MediaDistributorModel()
                {
                    Name = "Distributor #" + i,
                    Medias = this.GenerateMedias(i + 10)
                };

                distributors.Add(media);
            }

            return distributors;
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

        private ICollection<MediaModel> GenerateMedias(int count)
        {
            var medias = new List<MediaModel>();

            for (int i = 0; i < count; i++)
            {
                var media = new MediaModel()
                {
                    Name = "Media #" + i,
                    PriceSubscriptionPerMonth = 100 + i,
                    Type = (MediaType)Enum.Parse(typeof(MediaType), (i % 3).ToString())
                };

                medias.Add(media);
            }

            return medias;
        }
    }
}
