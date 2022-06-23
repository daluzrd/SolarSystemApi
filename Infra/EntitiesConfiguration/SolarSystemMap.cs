using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntitiesConfiguration
{
    public class SolarSystemMap : IEntityTypeConfiguration<SolarSystem>
    {
        public void Configure(EntityTypeBuilder<SolarSystem> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Name).IsRequired();
        }
    }
}