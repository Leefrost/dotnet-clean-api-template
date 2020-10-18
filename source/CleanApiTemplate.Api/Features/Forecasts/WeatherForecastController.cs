using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanApiTemplate.Application.Features.Forecast.Queries;
using CleanApiTemplate.Domain.Entities.Forecasts;
using Microsoft.AspNetCore.Mvc;

namespace CleanApiTemplate.Api.Features.Forecasts
{
    public class WeatherForecastController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var query = new GetAllForecastQuery(User?.Identity?.Name);
            var result = await Mediator.Send(query);

            return result.ToList();
        }
        
        [HttpGet("{locationId}")]
        public async Task<List<WeatherForecast>> Get(Guid locationId)
        {
            var query = new GetAllForecastForLocationQuery(User?.Identity?.Name, locationId);
            var result = await Mediator.Send(query);

            return result.ToList();
        }
    }
}
