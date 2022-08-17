using AspProMongoDb.WebApp.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace AspProMongoDb.WebApp.Entities
{
    public class User:BaseEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }
        public string Family { get; set; }
        [BsonIgnore]
        public string FullName => $"{Name} {Family}";
    }
}
