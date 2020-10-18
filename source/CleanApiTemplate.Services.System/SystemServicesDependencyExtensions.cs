using CleanApiTemplate.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApiTemplate.Services.System
{
    public static class SystemServicesDependencyExtensions
    {
        public static IServiceCollection AddSystemServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();

            return services;
        }
    }
}
