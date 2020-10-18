using CleanApiTemplate.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanApiTemplate.Persistence.Database.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Locations");

            builder.Property(t => t.City).IsRequired();

            builder.HasMany(x => x.Forecasts).WithOne(x => x.Location).HasForeignKey(x => x.LocationId);
        }
    }
}
