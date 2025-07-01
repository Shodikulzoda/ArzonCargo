using Microsoft.EntityFrameworkCore.Diagnostics;
using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Infrastructure.Repository;

namespace Stocky.WebApi.Extensions;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this IServiceCollection collection)
    {
        collection.AddScoped<IAuthRepository, AuthRepository>();
        collection.AddScoped<IOrderRepository, OrderRepository>();
        collection.AddScoped<IOrderItemRepository, OrderItemRepository>();
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IProductRepository, ProductRepository>();
        collection.AddScoped<IPocketItemRepository, PocketItemRepository>();
        collection.AddScoped<IPocketRepository, PocketRepository>();
    }
}