using System;
using System.Threading;
using System.Threading.Tasks;
using CleanApiTemplate.Application.Common;
using CleanApiTemplate.Domain.Entities.Forecasts;
using CleanApiTemplate.Domain.Entities.Locations;
using MediatR;

namespace CleanApiTemplate.Application.Features.Forecast.Commands
{
    public class AddNewForecastCommand : BaseCqrsRequest<Guid>
    {
        public AddNewForecastCommand(string appUser)
            : base(appUser)
        {
        }

        public int Temperature { get; set; }
        public string Wind { get; set; }
        public string Clouds { get; set; }
        public DateTime ForecastDate { get; set; }
        public string Summary { get; set; }

        public Guid Location { get; set; }

    }

    internal class AddNewForecastCommandHandler
        : IRequestHandler<AddNewForecastCommand, Guid>
    {
        private readonly IForecastDbContext _forecastDbContext;

        public AddNewForecastCommandHandler(IForecastDbContext forecastDbContext)
        {
            _forecastDbContext = forecastDbContext;
        }

        public async Task<Guid> Handle(AddNewForecastCommand request, CancellationToken cancellationToken)
        {
            //var forecast = new WeatherForecast
            //{
            //    Clouds = request.CreationData.Clouds,
            //    ForecastDate = request.CreationData.ForecastDate,
            //    ForecastLocation = new Location { Id = request.CreationData.Location },
            //    Summary = request.CreationData.Summary,
            //    Temperature = request.CreationData.Temperature,
            //    Wind = request.CreationData.Wind,
            //};

            //_mapper.Map()

            //_forecastDbContext.WeatherForecasts.Add(forecast);

            await _forecastDbContext.SaveChangesAsync(cancellationToken);

            return Guid.Empty;
        }
    }
}
