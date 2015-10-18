namespace MediaMonitoringSystem.MongoDb.ConsoleClient
{
    using System.Collections.Generic;

    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MediaDistributorModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<MediaModel> Medias { get; set; }
    }
}