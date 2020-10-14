using System;

namespace CleanApiTemplate.Domain.Entities.Forecasts
{
    public class WeatherForecastCreation
    {
        public int Temperature { get; set; }
        public string Wind { get; set; }
        public string Clouds { get; set; }
        public DateTime ForecastDate { get; set; }
        public string Summary { get; set; }

        public Guid Location { get; set; }
    }
}
