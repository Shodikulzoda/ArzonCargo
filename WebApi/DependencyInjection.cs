using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApi.Application.Interfaces;
using WebApi.Infrastructure.Repository;

namespace WebApi;

public static class DependencyInjection
{
    public static void Di(this IServiceCollection collection)
    {
        collection.AddTransient<IOrderRepository, OrderRepository>();
        collection.AddTransient<IOrderItemRepository, OrderItemRepository>();
        collection.AddTransient<IUserRepository, UserRepository>();
        collection.AddTransient<IProductRepository, ProductRepository>();
        collection.AddTransient<IPocketItemRepository, PocketRepository>();
    }
}