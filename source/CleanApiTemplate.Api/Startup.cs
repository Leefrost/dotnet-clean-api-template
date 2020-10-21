using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanApiTemplate.Api.Infrastructure;
using CleanApiTemplate.Persistence.Database;
using CleanApiTemplate.Services.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;

namespace CleanApiTemplate.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();

            services.AddApplication();
            services.AddDbStorage(Configuration);
            services.AddSystemServices();

            services.AddHealthChecks();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanTemplate Web API", Version = "v1" });

                options.AddSecurityDefinition("JWT", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "JWT authorization",
                    In = ParameterLocation.Header,
                    Description = "JWT token"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");

            app.UseSwagger(settings =>
            {
                settings.RouteTemplate = "api-docs/{documentName}/openapi.json";
            });

            app.UseSwaggerUI(settings =>
            {
                settings.DocumentTitle = "API Template description";
                settings.RoutePrefix = "api-docs";
                settings.SwaggerEndpoint("/api-docs/v1/openapi.json", "API Template description V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSerilogRequestLogging();
        }
    }
}
