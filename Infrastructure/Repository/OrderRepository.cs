using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderRepository(ApplicationContext context) : IOrderRepository
{
    public async Task<Order> Add(Order order)
    {
        var entity = context.Orders.Add(order).Entity;
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await context.Orders.ToListAsync();
    }

    public async Task<Order> Update(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> Delete(Order order)
    {
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<Order?> GetById(int id)
    {
        return await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
    }
}