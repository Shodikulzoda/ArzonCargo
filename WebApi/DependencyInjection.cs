using Application.Interfaces;
using Infrastructure.Repository;

namespace WebApi;

public static class DependencyInjection
{
    public static void Di(this IServiceCollection collection)
    {
        collection.AddScoped<IOrderRepository, OrderRepository>();
        collection.AddScoped<IOrderItemRepository, OrderItemRepository>();
    }
}