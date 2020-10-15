using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanApiTemplate.Application.Features.Forecast.Queries;
using CleanApiTemplate.Domain.Entities.Forecasts;
using Microsoft.AspNetCore.Mvc;

namespace CleanApiTemplate.Api.Controllers.Features.Forecasts
{
    public class WeatherForecastController : ApiController
    {
        [HttpGet("{location}")]
        public async Task<List<WeatherForecast>> Get(string location)
        {
            var query = new GetAllForecastForLocationQuery(User?.Identity?.Name, location);
            var result = await Mediator.Send(query);

            return result.ToList();
        }
    }
}
