using MongoDB.Bson.Serialization.Attributes;

namespace AspProMongoDb.WebApp.Entities
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        public string Family { get; set; }
        [BsonIgnore]
        public string FullName => $"{Name} {Family}";
    }
}
