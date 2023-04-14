using WeatherApp.Models;

namespace WeatherApp.Dto
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public WeatherDto? Weather { get; set; }
    }
}
