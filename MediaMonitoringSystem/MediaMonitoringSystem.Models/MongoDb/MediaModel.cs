namespace MediaMonitoringSystem.MongoDb.ConsoleClient
{
    using MediaMonitoringSystem.Models.MSSQL.Contracts;
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
