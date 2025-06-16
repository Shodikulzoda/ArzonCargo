using WebApi.Repository;
using WebApi.Repository.Interfaces;

namespace WebApi;

public static class DependencyInjection
{
    public static void Di(this IServiceCollection collection)
    {
        collection.AddScoped<IOrderRepository, OrderRepository>();
        collection.AddScoped<IOrderItemRepository, OrderItemRepository>();
    }
}