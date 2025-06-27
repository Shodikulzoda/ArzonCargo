using ReferenceClass.Models;

namespace WebApi.Application.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order> Add(Order order);
    Task<IEnumerable<Order>> GetAll();
    Task<Order> Update(Order order);
    Task<bool> Delete(int id);
    
    Task<Order?> GetById(int id);
    Task<IEnumerable<Order>> GetOrdersByUserId(int id);
    Task<int> Count();
    Task<IEnumerable<Order>> GetOrderByPagination(int page, int pageSize, CancellationToken cancellationToken);

}