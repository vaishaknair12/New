using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NewProject.Models
{
    [BsonIgnoreExtraElements]
    public class Building
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; } = String.Empty;

        public string buildingName { get; set; } = String.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public String VenueId { get; set; } = String.Empty;

        
    }
  

}

   


