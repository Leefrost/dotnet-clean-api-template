using CleanApiTemplate.Persistence.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApiTemplate.Api.Infrastructure.Identity
{
    public static class ApplicationIdentityExtensions
    {
        public static IServiceCollection AddAppAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationUserDbContext>(options =>
                    options.UseInMemoryDatabase("CleanApiTemplateDbUser"));
            }
            else
            {
                services.AddDbContext<ApplicationUserDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("CleanApiTemplateDbUser"),
                        b => b.MigrationsAssembly(typeof(ForecastDbContext).Assembly.FullName)));
            }

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationUserDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationUserDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt()
                .AddLocalApi(options =>
                {
                    options.ExpectedScope = "api";
                });

            services.AddCors(options =>
            {
                options.AddPolicy("api", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
