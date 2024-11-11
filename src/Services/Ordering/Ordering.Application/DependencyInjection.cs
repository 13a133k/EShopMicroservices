using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddTransient<IOrderService, OrderService>();
        //services.AddTransient<IOrderRepository, OrderRepository>();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}