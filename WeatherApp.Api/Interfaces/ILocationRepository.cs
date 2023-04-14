using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
    public interface ILocationRepository
    {
        ICollection<Location> GetLocations();
        Location GetLocation(int id);
        Location GetLocationByRegion(string region);
        Location GetLocationByGeo(double lat, double lon);
        bool LocationExists(int id);
        bool LocationExists(string region);
        bool LocationExists(double lat, double lon);
        bool CreateLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(Location location);
        bool Save();
    }
}
