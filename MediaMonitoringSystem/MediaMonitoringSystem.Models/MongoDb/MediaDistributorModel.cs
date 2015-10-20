namespace MediaMonitoringSystem.Models.MongoDb
{
    using System.Collections.Generic;
    using MediaMonitoringSystem.Models.Contracts;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MediaDistributorModel : IMediaDistributorModel 
    {
        public MediaDistributorModel()
        {
            this.Medias = new List<MediaModel>();
        }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<MediaModel> Medias { get; set; }
    }
}