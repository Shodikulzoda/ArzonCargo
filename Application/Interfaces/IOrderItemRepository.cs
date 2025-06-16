using Domain.Models;

namespace Application.Interfaces;

public interface IOrderItemRepository
{
    OrderItem Add(OrderItem order);
    IEnumerable<OrderItem> GetAll();
    OrderItem Update(OrderItem order);
    bool Delete(int id);
    
    OrderItem GetById(int id);
}