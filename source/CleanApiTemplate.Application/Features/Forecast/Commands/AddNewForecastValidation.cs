using FluentValidation;

namespace CleanApiTemplate.Application.Features.Forecast.Commands
{
    public class AddNewForecastValidation : AbstractValidator<AddNewForecastCommand>
    {
        public AddNewForecastValidation()
        {
            RuleFor(x => x.Summary).NotEmpty();
            RuleFor(x => x.LocationId).NotEmpty();
            RuleFor(x => x.Clouds).NotEmpty();
            RuleFor(x => x.Temperature).NotEmpty();
            RuleFor(x => x.TakeInDate).NotEmpty();
            RuleFor(x => x.Wind).NotEmpty();
        }
    }
}
