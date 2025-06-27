using ReferenceClass.Models;

namespace WebApi.Application.Interfaces;

public interface IOrderItemRepository:IBaseRepository<OrderItem>
{
    Task<OrderItem> Add(OrderItem orderItem);
    Task<IEnumerable<OrderItem>> GetAll();
    Task<OrderItem> Update(OrderItem orderItem);
    Task<bool> Delete(int id);

    Task<OrderItem?> GetById(int id);
    Task<int> Count();
    Task<IEnumerable<OrderItem>> GetOrderItemByPagination(int page, int pageSize, CancellationToken cancellationToken);
}