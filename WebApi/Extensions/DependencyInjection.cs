using WebApi.Application.Interfaces;
using WebApi.Infrastructure.Repository;

namespace WebApi.Extensions;

public static class DependencyInjection
{
    public static void Di(this IServiceCollection collection)
    {
        collection.AddScoped<IOrderRepository, OrderRepository>();
        collection.AddScoped<IOrderItemRepository, OrderItemRepository>();
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IProductRepository, ProductRepository>();
        collection.AddScoped<IPocketItemRepository, PocketRepository>();
    }
}