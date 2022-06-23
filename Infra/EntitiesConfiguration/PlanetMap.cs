using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    public class PlanetMap : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name).IsRequired();

            builder.Property(prop => prop.HasLife).IsRequired();

            builder.Property(prop => prop.Circumference).IsRequired();

            builder.Property(prop => prop.Population).IsRequired();

            builder.HasOne(prop => prop.SolarSystem)
                .WithMany(prop => prop.Planets)
                .HasForeignKey(prop => prop.SolarSystemId);
        }
    }
}