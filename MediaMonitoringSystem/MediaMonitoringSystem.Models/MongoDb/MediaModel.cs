namespace MediaMonitoringSystem.Models.MongoDb
{
    using MediaMonitoringSystem.Models.Contracts;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MediaModel : IMediaModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public MediaType Type { get; set; }

        public string Name { get; set; }

        public decimal PriceSubscriptionPerMonth { get; set; }
    }
}
