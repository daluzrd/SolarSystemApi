using Infra.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SsDbContext>(options =>
                            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                                    x => x.MigrationsAssembly(typeof(SsDbContext).Assembly.FullName)
                                ).EnableSensitiveDataLogging()
                            );

            return services;
        }
    }
}
