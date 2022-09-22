using NewProject.Models;

namespace NewProject.Services
{
    public interface IBuildingService
    {
        List<Building> Get();
        Building Get(string id);

        Building Create(Building building);

        void Update(string id, Building building);

        void Remove(string id);
    }
}
