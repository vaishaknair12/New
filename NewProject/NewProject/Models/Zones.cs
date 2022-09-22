using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewProject.Models
{
    [BsonIgnoreExtraElements]
    public class Zones
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        public string zonesName { get; set; } = String.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public String BuildingId { get; set; } = String.Empty;

    }
};