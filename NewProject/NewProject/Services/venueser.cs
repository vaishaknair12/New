using MongoDB.Bson;
using MongoDB.Driver;
using NewProject.Models;
using System.Collections.Generic;

namespace NewProject.Services
{
    public class venueser: ivenueser
    {
        private readonly IMongoCollection<Venue> _venueCollection;
        public venueser(IEmployeeDatabaseSettins settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _venueCollection = database.GetCollection<Venue>("Venue");

        }
        public Venue Create(Venue venue)
        {
            _venueCollection.InsertOne(venue);

            return venue;
        }

        public List<Venue> Get()
        {
            PipelineDefinition<Venue, Venue> pipeline = new[]



{
    new BsonDocument("$match",
    new BsonDocument("venue", "kiran")),
    new BsonDocument("$lookup",
    new BsonDocument
        {
            { "from", "Buildings" },
            { "localField", "_id" },
            { "foreignField", "VenueId" },
            { "as", "result" }
        }),
    new BsonDocument("$unwind",
    new BsonDocument
        {
            { "path", "$result" },
            { "preserveNullAndEmptyArrays", false }
        }),
    new BsonDocument("$match",
    new BsonDocument("result.buildingName", "xyz")),
    new BsonDocument("$lookup",
    new BsonDocument
        {
            { "from", "Zones" },
            { "localField", "result._id" },
            { "foreignField", "BuildingId" },
            { "as", "data" }
        }),
    new BsonDocument("$unwind",
    new BsonDocument
        {
            { "path", "$data" },
            { "preserveNullAndEmptyArrays", false }
        }),
    new BsonDocument("$addFields",
    new BsonDocument
        {
            { "final._id", "$_id" },
            { "final.venue", "$venue" },
            { "final.zoneName", "$data.zonesName" }
        }),
    new BsonDocument("$replaceRoot",
    new BsonDocument("newRoot", "$final"))
};
         //return _venueCollection.Find(venue => true).ToList();
         List<Venue> pResults = _venueCollection.Aggregate(pipeline).ToList();
          return pResults;
        }

        public Venue Get(string id)
        {
            return _venueCollection.Find(venue => venue.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _venueCollection.DeleteOne(venue => venue.Id == id);
        }

        public void Update(string id, Venue venues)
        {
            _venueCollection.ReplaceOne(venue => venue.Id == id, venues);
        }
    }
}

