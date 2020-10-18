using CleanApiTemplate.Domain.Entities.Forecasts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApiTemplate.Persistence.Database.Configurations
{
    public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Forecasts");

            builder.Property(t => t.Summary).IsRequired();
            builder.Property(t => t.Clouds).IsRequired();
            builder.Property(t => t.TakeInDate).IsRequired();
            builder.Property(t => t.Temperature).IsRequired();
            builder.Property(t => t.Wind).IsRequired();
        }
    }
}
