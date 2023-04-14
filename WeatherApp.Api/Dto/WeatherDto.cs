using System.ComponentModel.DataAnnotations.Schema;
using WeatherApp.Models;

namespace WeatherApp.Dto
{
    public class WeatherDto
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public double WindMph { get; set; }
        public double WindKph { get; set; }
        public string? Condition { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
    }
}
