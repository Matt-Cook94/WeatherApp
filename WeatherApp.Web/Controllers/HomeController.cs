using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using WeatherApp.Helpers;
using WeatherApp.Web.Helpers;
using WeatherApp.Web.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace WeatherApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private const string LocalBaseUrl = "https://localhost:7099/";
        private const string IpInfoBaseUrl = "https://ipinfo.io";
        private const string WeatherApiBaseUrl = "http://api.weatherapi.com/v1/";

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string location)
        {
            try
            {
                var ipInfoApiKey = _config["IpInfoApiKey"];
                var weatherApiKey = _config["WeatherApiKey"];

                if (location == null)
                {
                    var ipInfoUrl = $"{IpInfoBaseUrl}?token={ipInfoApiKey}";
                    var info = new WebClient().DownloadString(ipInfoUrl);
                    IPInfo ipInfo = new IPInfo();
                    ipInfo = JsonConvert.DeserializeObject<IPInfo>(info);
                    location = ipInfo.City;
                }
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WeatherApiBaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUrl = $"forecast.json?key={weatherApiKey}&q={location}&days=7&aqi=no&alerts=no";
                    HttpResponseMessage res = await client.GetAsync(requestUrl);

                    if (res.IsSuccessStatusCode)
                    {
                        var jsonResult = res.Content.ReadAsStringAsync().Result;

                        var weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(jsonResult);
                        
                        var locationViewModel = new LocationViewModel()
                        {
                            Name = weatherInfo.Location.Name,
                            Weather = new WeatherViewModel()
                            {
                                TemperatureC = double.Parse(weatherInfo.Current.TempC),
                                Condition = weatherInfo.Current.Condition.Text,
                                MinTempC = double.Parse(weatherInfo.Forecast.ForecastDay[0].Day.MinTempC),
                                MaxTempC = double.Parse(weatherInfo.Forecast.ForecastDay[0].Day.MaxTempC)
                            }
                        };

                        return View(weatherInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LocationViewModel locationViewModel)
        {
            //Calling the web API and populating the data in view using LocationViewModel
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(LocalBaseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync($"Location/{locationViewModel.Id}");

                if (getData.IsSuccessStatusCode)
                {
                    var jsonResult = getData.Content.ReadAsStringAsync().Result;

                    var locationData = JsonConvert.DeserializeObject<LocationViewModel>(jsonResult);
                    
                    return View(locationData);
                }
                else
                {
                    Console.WriteLine("Error calling web API");
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}