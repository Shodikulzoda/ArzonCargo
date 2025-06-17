using Domain.Models;

namespace Application.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order> Add(Order order);
    Task<IEnumerable<Order>> GetAll();
    Task<Order> Update(Order order);
    Task<Order> Delete(Order order);
    Task<Order?> GetById(int id);
}