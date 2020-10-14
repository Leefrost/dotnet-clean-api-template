using System;
using System.Collections.Generic;
using CleanApiTemplate.Domain.Common;
using CleanApiTemplate.Domain.Entities.Forecasts;

namespace CleanApiTemplate.Domain.Entities.Locations
{
    public class Location : IEntity<Guid>
    {
        public Location()
        {
            Forecasts = new List<WeatherForecast>();
        }

        public Guid Id { get; set; }
        
        public string City { get; set; }

        public IList<WeatherForecast> Forecasts { get; }
    }
}
