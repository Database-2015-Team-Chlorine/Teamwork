namespace MediaMonitoringSystem.MongoDb.ConsoleClient
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MediaModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal PriceSubscriptionPerMonth { get; set; }
    }
}
