using System;
using System.Linq;
using System.Threading.Tasks;
using CleanApiTemplate.Application.Common;
using CleanApiTemplate.Domain.Entities.Forecasts;
using CleanApiTemplate.Domain.Entities.Locations;

namespace CleanApiTemplate.Persistence.Database
{
    public static class ForecastDbContextSeed
    {
        public static async Task SeedBaseDataAsync(IForecastDbContext context)
        {
            if (!context.WeatherForecasts.Any())
            {
                var locationId = Guid.NewGuid();
                var weatherId = Guid.NewGuid();

                await context.Locations.AddAsync(new Location
                {
                    Id = locationId,
                    City = "London"
                });

                await context.WeatherForecasts.AddAsync(new WeatherForecast
                {
                    Id = weatherId,
                    LocationId = locationId,
                    Wind = "West",
                    Clouds = "Medium",
                    TakeInDate = DateTime.Now,
                    Summary = "Cold",
                    Temperature = 10,
                });

                await context.SaveChangesAsync(default);
            }
        }
    }
}
