namespace WeatherApp.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public Weather? Weather { get; set; }
    }
}
