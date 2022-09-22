using NewProject.Models;

namespace NewProject.Services
{
    public interface iZonesInterface
    {
        List<Zones> Get();
        Zones Get(string id);

        Zones Create(Zones zone);

        void Update(string id, Zones zone);

        void Remove(string id);
    }
}
