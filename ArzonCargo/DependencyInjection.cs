using ArzonCargo.Repository;
using ArzonCargo.Repository.Interfaces;

namespace ArzonCargo;

public static class DependencyInjection
{
    public static void Di(this IServiceCollection collection)
    {
        collection.AddScoped<IOrderRepository, OrderRepository>();
        collection.AddScoped<IOrderItemRepository, OrderItemRepository>();
    }
}