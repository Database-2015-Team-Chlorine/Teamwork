namespace MediaMonitoringSystem.MongoDb.ConsoleClient
{
    using System.Collections.Generic;
    using MediaMonitoringSystem.Models.Contracts;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MediaDistributorModel : IMediaDistributorModel 
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<IMediaModel> Medias { get; set; }
    }
}