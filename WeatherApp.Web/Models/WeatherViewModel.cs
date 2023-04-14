using System.ComponentModel.DataAnnotations.Schema;
using WeatherApp.Helpers;

namespace WeatherApp.Web.Models
{
    public class WeatherViewModel
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public double TemperatureC { get; set; }
        public double TemperatureF { get; set; }
        public double MaxTempC { get; set; }
        public double MaxTempF { get; set; }
        public double MinTempC { get; set; }
        public double MinTempF { get; set; }
        public double WindMph { get; set; }
        public double WindKph { get; set; }
        public double PressureMb { get; set; }
        public double PressureIn { get; set; }
        public double PrecipMm { get; set; }
        public double PrecipIn { get; set; }
        public double Humidity { get; set; }
        public double Cloud { get; set; }
        public double FeelsLikeC { get; set; }
        public double FeelsLike { get; set; }
        public double VisKm { get; set; }
        public double VisMiles { get; set; }
        public double Uv { get; set; }
        public string? Condition { get; set; }
        public Forecast Forecast { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }
    }
}
