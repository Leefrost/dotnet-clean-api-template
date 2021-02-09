using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanApiTemplate.Application.Common;
using CleanApiTemplate.Domain.Entities.Forecasts;
using MediatR;

namespace CleanApiTemplate.Application.Features.Forecast.Queries
{
    public class GetAllForecastQuery : BaseCqrsRequest<IEnumerable<WeatherForecast>>
    {
        public GetAllForecastQuery(string appUser)
            : base(appUser)
        {
        }
    }

    internal class GetAllForecastQueryHandler : IRequestHandler<GetAllForecastQuery, IEnumerable<WeatherForecast>>
    {
        private readonly IForecastDbContext _context;

        public GetAllForecastQueryHandler(IForecastDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<WeatherForecast>> Handle(GetAllForecastQuery request, CancellationToken cancellationToken)
        {
            var source = _context.WeatherForecasts.AsEnumerable();

            return Task.FromResult(source);
        }
    }
}
