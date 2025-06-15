using ArzonCargo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>((sp, options) =>
{
    options.UseMySQL(connection)
        .LogTo(Console.WriteLine, LogLevel.Information);
    // .AddInterceptors(sp.GetRequiredService<SavingInterceptor>());
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
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