using Newtonsoft.Json;

namespace WeatherApp.Helpers
{
    public class WeatherInfo
    {
        [JsonProperty("location")]
        public Location Location = new Location();

        [JsonProperty("current")]
        public Current Current = new Current();

        [JsonProperty("forecast")]
        public Forecast Forecast = new Forecast();
    }

    public class Location
    {
        [JsonProperty("name")]
        public string Name;
        
        [JsonProperty("region")]
        public string Region;

        [JsonProperty("country")]
        public string Country;

        [JsonProperty("lat")]
        public string Lat;

        [JsonProperty("tz_id")]
        public string TzId;

        [JsonProperty("localtime_epoch")]
        public string LocalTimeEpoch;

        [JsonProperty("localtime")]
        public string LocalTime;
    }

    public class Current
    {
        [JsonProperty("last_updated_epoch")]
        public string LastUpdatedEpoch;

        [JsonProperty("last_updated")]
        public string LastUpdated;

        [JsonProperty("temp_c")]
        public string TempC;

        [JsonProperty("temp_f")]
        public string TempF;

        [JsonProperty("is_day")]
        public string IsDay;

        [JsonProperty("condition")]
        public Condition Condition = new Condition();

        [JsonProperty("wind_mph")]
        public string WindMph;

        [JsonProperty("wind_kph")]
        public string WindKph;

        [JsonProperty("wind_degree")]
        public string WindDegree;

        [JsonProperty("wind_dir")]
        public string WindDir;

        [JsonProperty("pressure_mb")]
        public string PressureMb;

        [JsonProperty("pressure_in")]
        public string PressureIn;

        [JsonProperty("precip_mm")]
        public string PrecipMm;

        [JsonProperty("precip_in")]
        public string PrecipIn;

        [JsonProperty("humidity")]
        public string Humidity;

        [JsonProperty("cloud")]
        public string Cloud;

        [JsonProperty("feelslike_c")]
        public string FeelsLikeC;

        [JsonProperty("feelslike_f")]
        public string FeelsLikeF;

        [JsonProperty("vis_km")]
        public string VisKm;

        [JsonProperty("vis_miles")]
        public string VisMiles;

        [JsonProperty("uv")]
        public string Uv;

        [JsonProperty("gust_mph")]
        public string GustMph;

        [JsonProperty("gust_kph")]
        public string GustKph;
    }

    public class Condition
    {
        [JsonProperty("text")]
        public string Text;

        [JsonProperty("icon")]
        public string Icon;

        [JsonProperty("code")]
        public string Code;
    }

    public class Forecast
    {
        [JsonProperty("forecastday")]
        public ForecastDay[] ForecastDay = new ForecastDay[7];
    }

    public class ForecastDay
    {
        [JsonProperty("date")]
        public string Date;

        [JsonProperty("day")]
        public Day Day = new Day();
    }

    public class Day
    {
        [JsonProperty("maxtemp_c")]
        public string MaxTempC;

        [JsonProperty("maxtemp_f")]
        public string MaxTempf;

        [JsonProperty("mintemp_c")]
        public string MinTempC;

        [JsonProperty("mintemp_f")]
        public string MinTempf;

        [JsonProperty("condition")]
        public Condition Condition = new Condition();
    }
}
