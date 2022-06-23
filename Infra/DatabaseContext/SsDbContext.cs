using Microsoft.EntityFrameworkCore;

namespace Infra.DatabaseContext
{
    public class SsDbContext : DbContext
    {
        public SsDbContext(DbContextOptions<SsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SsDbContext).Assembly);
        }
    }
}
