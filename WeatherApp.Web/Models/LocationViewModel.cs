using System.ComponentModel.DataAnnotations.Schema;
using WeatherApp.Dto;

namespace WeatherApp.Web.Models
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public DateTime LocalTime { get; set; }
        public WeatherViewModel? Weather { get; set; }
    }
}
