using System.Threading;
using System.Threading.Tasks;
using CleanApiTemplate.Domain.Entities.Forecasts;
using CleanApiTemplate.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace CleanApiTemplate.Application.Common
{
    public interface IForecastDbContext
    {
        DbSet<WeatherForecast> WeatherForecasts { get; set; }

        DbSet<Location> Locations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}