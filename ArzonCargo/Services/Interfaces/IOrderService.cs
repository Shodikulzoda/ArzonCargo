using ArzonCargo.Models;

namespace ArzonCargo.Repositories.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> GetAll();
    Order GetById(Guid id);
    Order Create(Order order);
    Order Update(Order order);
    bool Delete(Guid id);
    
}