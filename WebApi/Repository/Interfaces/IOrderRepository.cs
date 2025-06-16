using WebApi.Models;

namespace WebApi.Repository.Interfaces;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    Order GetById(Guid id);
    Order Create(Order order);
    Order Update(Order order);
    bool Delete(Guid id);
    
}