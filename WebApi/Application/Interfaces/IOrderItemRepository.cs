using WebApi.Domain.Models;

namespace WebApi.Application.Interfaces;

public interface IOrderItemRepository:IBaseRepository<OrderItem>
{
    Task<OrderItem> Add(OrderItem orderItem);
    Task<IEnumerable<OrderItem>> GetAll();
    Task<OrderItem> Update(OrderItem orderItem);
    Task<bool> Delete(OrderItem orderItem);
    Task<OrderItem?> GetById(int id);
}