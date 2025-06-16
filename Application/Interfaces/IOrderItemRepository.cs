using Domain.Models;

namespace Application.Interfaces;

public interface IOrderItemRepository
{
    Task<OrderItem> Add(OrderItem orderItem);
    Task<IEnumerable<OrderItem>> GetAll();
    Task<OrderItem> Update(OrderItem orderItem);
    Task<OrderItem> Delete(OrderItem orderItem);
    Task<OrderItem?> GetById(int id);
}