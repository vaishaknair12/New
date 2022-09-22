using MongoDB.Driver;
using NewProject.Models;

namespace NewProject.Services
{
    public class Zonesser : iZonesInterface
    {
        private readonly IMongoCollection<Zones> _ZoneCollection;
        public Zonesser(IEmployeeDatabaseSettins settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _ZoneCollection = database.GetCollection<Zones>("Zones");

        }
        public Zones Create(Zones zone)
        {
            _ZoneCollection.InsertOne(zone);

            return zone;
        }

        public List<Zones> Get()
        {
            return _ZoneCollection.Find(zone => true).ToList();
        }

        public Zones Get(string id)
        {
            return _ZoneCollection.Find(zone => zone.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _ZoneCollection.DeleteOne(zone => zone.Id == id);
        }

        public void Update(string id, Zones zones)
        {
            _ZoneCollection.ReplaceOne(zone => zone.Id == id, zones);
        }

    }
}
