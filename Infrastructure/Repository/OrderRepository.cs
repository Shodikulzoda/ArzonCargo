using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class OrderRepository(ApplicationContext context) : IOrderRepository
{
    public Order Add(Order order)
    {
        var entity = context.Orders.Add(order).Entity;
        context.SaveChanges();
        return entity;
    }

    public IEnumerable<Order> GetAll()
    {
        throw new NotImplementedException();
    }
    
    public Order Update(Order order)
    {
        context.Orders.Update(order);
        context.SaveChanges();
        return order;
    }

    public bool Delete(int id)
    {
        var order = GetById(id);
        if (order == null)
            throw new Exception("Order not found");
        context.Orders.Remove(order);
        context.SaveChanges();
        return true;
    }

    public Order GetById(int id)
    {
        var order = context.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null)
            throw new Exception("Order not found");
        return order;
    }
}