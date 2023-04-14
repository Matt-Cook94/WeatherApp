using WeatherApp.Data;
using WeatherApp.Models;

namespace WeatherApp
{
    public class Seed
    {
        private readonly ApplicationDbContext _context;

        public Seed(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedApplicationDbContext()
        {
            if (!_context.Locations.Any())
            {
                var locationList = new List<Location>()
                {
                    new Location()
                    {
                        Country = "Australia",
                        Region = "Brisbane",
                        Lat = 27.470,
                        Lon = 153.02,
                        Weather = new Weather()
                        {
                            LastUpdated = DateTime.Now,
                            TemperatureC = 28,
                            TemperatureF = 82.4,
                            WindKph = 4.7,
                            WindMph = 2.92,
                            Condition = "Sunny",
                        },
                    },
                    new Location()
                    {
                        Country = "United Kingdom",
                        Region = "London",
                        Lat = 51.507,
                        Lon = 0.1276,
                        Weather = new Weather()
                        {
                            LastUpdated = DateTime.Now,
                            TemperatureC = 14,
                            TemperatureF = 57.2,
                            WindKph = 8.2,
                            WindMph = 5.09,
                            Condition = "Partly Cloudy"
                        },
                    }
                };
                _context.Locations.AddRange(locationList);
                _context.SaveChanges();
            }
        }
    }
}
