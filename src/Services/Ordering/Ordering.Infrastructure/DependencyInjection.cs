using Microsoft.Extensions.Configuration;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        //Add services to the container.
        // services.AddDbContext<ApplicationDbContext>((sp, options) =>
        // {
        //     options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        //     options.UseSqlServer(connectionString);
        // });

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}