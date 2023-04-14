using AutoMapper;
using WeatherApp.Dto;
using WeatherApp.Models;

namespace WeatherApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<Weather, WeatherDto>();
            CreateMap<WeatherDto, Weather>();
        }
    }
}
