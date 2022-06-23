using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DatabaseContext
{
    public class SsDbContext : DbContext
    {
        public SsDbContext(DbContextOptions<SsDbContext> options) : base(options) {}

        public DbSet<SolarSytem> SolarSytem { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SsDbContext).Assembly);
        }
    }
}
