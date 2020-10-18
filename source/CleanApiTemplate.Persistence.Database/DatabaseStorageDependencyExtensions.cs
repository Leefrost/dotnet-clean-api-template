using CleanApiTemplate.Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApiTemplate.Persistence.Database
{
    public static class DatabaseStorageDependencyExtensions
    {
        public static IServiceCollection AddDbStorage(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ForecastDbContext>(options =>
                    options.UseInMemoryDatabase("CleanApiTemplateDb"));
            }
            else
            {
                services.AddDbContext<ForecastDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("ForecastDbConnection"),
                        b => b.MigrationsAssembly(typeof(ForecastDbContext).Assembly.FullName)));
            }

            services.AddScoped<IForecastDbContext>(provider => provider.GetService<ForecastDbContext>());

            return services;
        }
    }
}
