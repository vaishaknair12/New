using NewProject.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace NewProject.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IMongoCollection<Building> _employeeCollection;
        public BuildingService (IEmployeeDatabaseSettins settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _employeeCollection = database.GetCollection<Building>("Buildings");

        }
        public Building Create(Building building)
        {
           _employeeCollection.InsertOne(building); 
           
            return building;
        }

        public  List<Building> Get()
        {
            BsonDocument pipeline = new BsonDocument{
                {
                    "$match", new BsonDocument{
                        { "buildingName", "xyz" }
                    }
                }
            };
            BsonDocument pipelineStage3 = new BsonDocument{
                {
                "$lookup", new BsonDocument{
                       
            { "from", "Zones" },
            { "localField", "_id" },
            { "foreignField", "BuildingId" },
            { "as", "result" }
           }
         }
       };
           BsonDocument pipelineStage4 = new BsonDocument{
                { "$unwind", "$result" }
          };
           BsonDocument pipelineStage5 = new BsonDocument{
               {
                 "$project", new BsonDocument{
               { "_id", 1 },
                 }
                 }
          };
            BsonDocument[] pipeline1 = new BsonDocument[] {
              pipeline,
              pipelineStage3,
              pipelineStage4,
              pipelineStage5
            };
            // Building building = new Building();
            List<Building> pResults = _employeeCollection.Aggregate<Building>(pipeline1).ToList();
            
            return pResults;


        }

        public Building Get(string id)
        {
            return _employeeCollection.Find(building => building.Id == id).FirstOrDefault();
         }

        public void Remove(string id)
        {
            _employeeCollection.DeleteOne(building => building.Id == id);
        }

        public void Update(string id, Building building)
        {
            _employeeCollection.ReplaceOne(building => building.Id == id, building);
        }
    }
}
