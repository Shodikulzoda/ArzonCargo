using ArzonCargo.Models;

namespace ArzonCargo.Repository.Interfaces;

public interface IOrderItemRepository
{
    OrderItem Create(OrderItem order);
    IEnumerable<OrderItem> GetAll();
    OrderItem Update(OrderItem order);
    bool Delete(Guid id);
    
    OrderItem GetById(Guid id);
}