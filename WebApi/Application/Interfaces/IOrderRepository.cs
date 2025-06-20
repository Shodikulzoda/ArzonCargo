﻿using ReferenceClass.Models;

namespace WebApi.Application.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<Order> Add(Order order);
    Task<IEnumerable<Order>> GetAll();
    Task<Order> Update(Order order);
    Task<Order> Delete(Order order);
    Task<Order?> GetById(int id);
    Task<int> Count();
    Task<IEnumerable<Order>> GetOrderByPagination(int page, int pageSize, CancellationToken cancellationToken);

}