using Stocky.WebApi.Application.Interfaces;
using Stocky.WebApi.Application.Services;
using Stocky.WebApi.Application.Services.Interfaces;
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
        collection.AddScoped<IPriceListRepository, PriceListRepository>();
        collection.AddScoped<IReportRepository, ReportRepository>();

        collection.AddScoped<IJwtService, JwtService>();
    }
}