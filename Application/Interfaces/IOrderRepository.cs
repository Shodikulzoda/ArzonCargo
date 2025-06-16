using Domain.Models;

namespace Infrastructure.Repository.Interfaces;

public interface IOrderRepository
{
    IEnumerable<Order> GetAll();
    Order GetById(Guid id);
    Order Create(Order order);
    Order Update(Order order);
    bool Delete(Guid id);
    
}