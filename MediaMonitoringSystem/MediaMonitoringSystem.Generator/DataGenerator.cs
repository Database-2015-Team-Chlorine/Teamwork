namespace MediaMonitoringSystem.Generator
{
    using System;
    using System.Collections.Generic;
    using MediaMonitoringSystem.Models.Contracts;
    using MediaMonitoringSystem.Models.MongoDb;

    public class DataGenerator
    {
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

        public ICollection<MediaModel> GenerateMedias(int count)
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
