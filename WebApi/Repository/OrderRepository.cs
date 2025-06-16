using WebApi.Infrastructure.Data;
using WebApi.Models;
using WebApi.Repository.Interfaces;

namespace WebApi.Repository;

public class OrderRepository(ApplicationContext context) : IOrderRepository
{
    public IEnumerable<Order> GetAll()
    {
        return context.Orders.ToList();
    }

    public Order GetById(Guid id)
    {
        var order = context.Orders.FirstOrDefault(o => o.Id == id);
        if (order == null) 
            throw new Exception("Order not found");
        return order;
    }

    public Order Create(Order order)
    {
        var entity = context.Orders.Add(order).Entity;
        context.SaveChanges();
        return entity ;
    }

    public Order Update(Order order)
    {
        var existingOrder = GetById(order.Id);
        if(existingOrder == null)
            throw new Exception("Order not found");
        context.Orders.Update(order);
        context.SaveChanges();
        return order;
    }

    public bool Delete(Guid id)
    {
        var order = GetById(id);
        if(order == null)
            throw new Exception("Order not found");
        context.Orders.Remove(order);
        context.SaveChanges();
        return true;
    }
}