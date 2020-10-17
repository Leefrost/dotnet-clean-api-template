using AutoMapper;
using CleanApiTemplate.Application.Features.Forecast.Commands;
using CleanApiTemplate.Domain.Entities.Forecasts;
using CleanApiTemplate.Domain.Entities.Locations;

namespace CleanApiTemplate.Application.Features.Forecast
{
    public class WeatherForecastMappingProfile : Profile
    {
        public WeatherForecastMappingProfile()
        {
            CreateMap<AddNewForecastCommand, WeatherForecast>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Location { Id = src.LocationId }));
        }
    }
}
