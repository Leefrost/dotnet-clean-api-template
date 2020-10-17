using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanApiTemplate.Application.Common;
using CleanApiTemplate.Domain.Entities.Forecasts;
using MediatR;

namespace CleanApiTemplate.Application.Features.Forecast.Queries
{
    public class GetAllForecastForLocationQuery : BaseCqrsRequest<IQueryable<WeatherForecast>>
    {
        public GetAllForecastForLocationQuery(string appUser, Guid locationId)
            : base(appUser)
        {
            LocationId = locationId;
        }

        public Guid LocationId { get; }
    }

    internal class GetAllForecastForLocationQueryHandler
        : IRequestHandler<GetAllForecastForLocationQuery, IQueryable<WeatherForecast>>
    {
        private readonly IForecastDbContext _context;

        public GetAllForecastForLocationQueryHandler(IForecastDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<WeatherForecast>> Handle(GetAllForecastForLocationQuery request, CancellationToken cancellationToken)
        {
            var source = _context.WeatherForecasts
                .Where(x => x.Location.Id == request.LocationId);

            return Task.FromResult(source);
        }
    }
}
