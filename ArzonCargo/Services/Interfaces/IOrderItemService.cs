using ArzonCargo.Models;

namespace ArzonCargo.Repositories.Interfaces;

public interface IOrderItemService
{
    IEnumerable<OrderItem> GetAll();
    OrderItem GetById(Guid id);
    OrderItem Create(OrderItem order);
    OrderItem Update(OrderItem order);
    bool Delete(Guid id);
}