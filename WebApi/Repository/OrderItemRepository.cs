using WebApi.Infrastructure.Data;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository;

public class OrderItemRepository(ApplicationContext context) : IOrderItemRepository
{
    public IEnumerable<OrderItem> GetAll()
    {
        return context.OrderItems.ToList();
    }

    public OrderItem GetById(Guid id)
    {
        var orderItem = context.OrderItems.FirstOrDefault(o => o.Id == id);
        if (orderItem == null)
            throw new Exception("OrderItem not found");
        return orderItem;
    }

    public OrderItem Create(OrderItem order)
    {
        if (order is null)
            throw new Exception("OrderItem is null");
        var entity = context.OrderItems.Add(order).Entity;
        context.SaveChanges();
        return entity;
    }

    public OrderItem Update(OrderItem order)
    {
        if (order is null)
            throw new Exception("OrderItem is null");
        context.OrderItems.Update(order);
        context.SaveChanges();
        return order;
    }

    public bool Delete(Guid id)
    {
        var orderItem = GetById(id);
        if (orderItem == null)
            throw new Exception("OrderItem not found");
        context.OrderItems.Remove(orderItem);
        context.SaveChanges();
        return true;
    }
}