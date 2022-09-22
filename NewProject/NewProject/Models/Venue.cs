using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NewProject.Models
{
    [BsonIgnoreExtraElements]
    public class Venue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; } = String.Empty;

        public string venue { get; set; } = String.Empty;

        public string City { get; set; } = String.Empty;
    }

};
