using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class OrderItemRepository(ApplicationContext context) : IOrderItemRepository
{
    public IEnumerable<OrderItem> GetAll()
    {
        return context.OrderItems.ToList();
    }

    public OrderItem GetById(int id)
    {
        var orderItem = context.OrderItems.FirstOrDefault(o => o.Id == id);
        if (orderItem == null)
            throw new Exception("OrderItem not found");
        return orderItem;
    }

    public OrderItem Add(OrderItem order)
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

    public bool Delete(int id)
    {
        var orderItem = GetById(id);
        if (orderItem == null)
            throw new Exception("OrderItem not found");
        context.OrderItems.Remove(orderItem);
        context.SaveChanges();
        return true;
    }
}