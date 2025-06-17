using WebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Application.Interfaces;
using WebApi.Application.ProductData.Queries.GetUserById;
using WebApi.Application.UserData.Commands.CreateUser;
using WebApi.Application.UserData.Commands.DeleteUser;
using WebApi.Application.UserData.Commands.UpdateUser;
using WebApi.Infrastructure.Data;
using WebApi.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Di();
builder.Services.AddScoped<IPocketItemRepository,PocketRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddOpenApi();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>((options) =>
{
    options.UseMySQL(connection!)
        .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bank application APIs", Version = "v1" });
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetUserByIdHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UpdateUserHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(DeleteUserHandler).Assembly);
});


var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.EnableTryItOutByDefault(); });
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();