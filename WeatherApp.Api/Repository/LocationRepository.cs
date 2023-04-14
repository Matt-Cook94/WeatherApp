using Microsoft.EntityFrameworkCore;
using WeatherApp.Data;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;
        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateLocation(Location location)
        {
            _context.Add(location);
            return Save();
        }

        public bool DeleteLocation(Location location)
        {
            _context.Remove(location);
            return Save();
        }

        public ICollection<Location> GetLocations()
        {
            return _context.Locations.Include(w => w.Weather).ToList();
        }

        public Location GetLocation(int id)
        {
            return _context.Locations.Where(l => l.Id == id).Include(w => w.Weather).FirstOrDefault();
        }

        public Location GetLocationByGeo(double lat, double lon)
        {
            return _context.Locations.Where(l => l.Lat == lat && l.Lon == lon).Include(w => w.Weather).FirstOrDefault();
        }

        public Location GetLocationByRegion(string region)
        {
            return _context.Locations.Where(l => l.Region == region).Include(w => w.Weather).FirstOrDefault();
        }

        public bool LocationExists(int id)
        {
            return _context.Locations.Any(l => l.Id == id);
        }
        public bool LocationExists(string region)
        {
            return _context.Locations.Any(l => l.Region == region);
        }

        public bool LocationExists(double lat, double lon)
        {
            return _context.Locations.Any(l => l.Lat == lat && l.Lon == lon);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateLocation(Location location)
        {
            _context.Update(location);
            return Save();
        }
    }
}
