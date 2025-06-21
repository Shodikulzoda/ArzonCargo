using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repository;

public class OrderItemRepository(ApplicationContext context) : BaseRepository<OrderItem>(context), IOrderItemRepository
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

    public async Task<bool> Delete(OrderItem orderItem)
    {
        context.OrderItems.Remove(orderItem);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<int> Count()
    {
        return await context.OrderItems.CountAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await context.OrderItems
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}