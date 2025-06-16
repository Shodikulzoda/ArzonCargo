using Domain.Models;

namespace Application.Interfaces;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    Order GetById(int id);
    Order Add(Order order);
    Order Update(Order order);
    bool Delete(int id);
    
}