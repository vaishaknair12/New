using NewProject.Models;

namespace NewProject.Services
{
    public interface ivenueser
    {
        List<Venue> Get();
        Venue Get(string id);

        Venue Create(Venue venue);

        void Update(string id, Venue venues);

        void Remove(string id);
    }
}
