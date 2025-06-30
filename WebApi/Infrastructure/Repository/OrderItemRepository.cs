using Microsoft.EntityFrameworkCore;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;
using WebApi.Infrastructure.Data;

namespace WebApi.Infrastructure.Repository;

public class OrderItemRepository(ApplicationContext context) : BaseRepository<OrderItem>(context), IOrderItemRepository
{
    private readonly ApplicationContext _context1 = context;

    public async Task<OrderItem> Add(OrderItem orderItem)
    {
        _context1.OrderItems.Add(orderItem);
        await _context1.SaveChangesAsync();

        return orderItem;
    }

    public async Task<IEnumerable<OrderItem>> GetAll()
    {
        return await _context1.OrderItems.ToListAsync();
    }

    public async Task<OrderItem?> GetById(int id)
    {
        return await _context1.OrderItems.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<OrderItem> Update(OrderItem order)
    {
        _context1.OrderItems.Update(order);
        await _context1.SaveChangesAsync();

        return order;
    }

    public async Task<bool> Delete(int id)
    {
        var orderItem = await _context1.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
        if (orderItem is null)
        {
            return false;
        }

        _context1.OrderItems.Remove(orderItem);
        await _context1.SaveChangesAsync();

        return true;
    }

    public async Task<int> Count()
    {
        return await _context1.OrderItems.CountAsync();
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemByPagination(int page, int pageSize,
        CancellationToken cancellationToken)
    {
        return await _context1.OrderItems
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}