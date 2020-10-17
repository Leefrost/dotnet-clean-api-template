using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanApiTemplate.Application.Common;
using CleanApiTemplate.Domain.Entities.Forecasts;
using MediatR;

namespace CleanApiTemplate.Application.Features.Forecast.Commands
{
    public class AddNewForecastCommand : BaseCqrsRequest<Guid>
    {
        public AddNewForecastCommand(string appUser)
            : base(appUser)
        { }

        public int Temperature { get; set; }
        public string Wind { get; set; }
        public string Clouds { get; set; }
        public DateTime TakeInDate { get; set; }
        public string Summary { get; set; }

        public Guid LocationId { get; set; }

    }

    internal class AddNewForecastCommandHandler : IRequestHandler<AddNewForecastCommand, Guid>
    {
        private readonly IForecastDbContext _forecastDbContext;
        private readonly IMapper _mapper;

        public AddNewForecastCommandHandler(IForecastDbContext forecastDbContext, IMapper mapper)
        {
            _forecastDbContext = forecastDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddNewForecastCommand request, CancellationToken cancellationToken)
        {
            var forecast = _mapper.Map<AddNewForecastCommand, WeatherForecast>(request);

            var forecastId = await _forecastDbContext.WeatherForecasts.AddAsync(forecast, cancellationToken);
            await _forecastDbContext.SaveChangesAsync(cancellationToken);

            return forecastId.Entity.Id;
        }
    }
}
