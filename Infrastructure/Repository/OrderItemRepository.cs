using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderItemRepository(ApplicationContext context) : IOrderItemRepository
{
    public async Task<OrderItem> Add(OrderItem order)
    {
        var entity = context.OrderItems.Add(order).Entity;
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<OrderItem>> GetAll()
    {
        return await context.OrderItems.ToListAsync();
    }

    public async Task<OrderItem?> GetById(int id)
    {
        return await context.OrderItems.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<OrderItem> Update(OrderItem order)
    {
        context.OrderItems.Update(order);
        await context.SaveChangesAsync();

        return order;
    }

    public async Task<OrderItem> Delete(OrderItem orderItem)
    {
        context.OrderItems.Remove(orderItem);
        await context.SaveChangesAsync();

        return orderItem;
    }
}