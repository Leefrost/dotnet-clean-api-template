using System.Reflection;
using AutoMapper;
using CleanApiTemplate.Application.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanApiTemplate.Api.Infrastructure
{
    public static class ApplicationDependencyExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assemblyList = new[]
            {
                typeof(BaseCqrsRequest<>).Assembly,
                Assembly.GetExecutingAssembly()
            };

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(assemblyList);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            return services;
        }
    }
}
