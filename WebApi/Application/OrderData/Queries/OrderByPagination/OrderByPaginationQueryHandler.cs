using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Common;
using WebApi.Application.Interfaces;

namespace WebApi.Application.OrderData.Queries.OrderByPagination;

public record OrderByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<Order>>;

public class OrdersByPaginationQueryHandler(IOrderRepository orderRepository)
    : IRequestHandler<OrderByPaginationQuery, PaginatedList<Order>>
{
    public async Task<PaginatedList<Order>> Handle(OrderByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await orderRepository
            .GetOrderByPagination(request.Page, request.PageSize, cancellationToken);

        var totalCount = await orderRepository.Count();

        var orderResponses = orders
            .Select(x => new Order
            {
                BarCode = x.BarCode,
                Status = x.Status,
                TotalAmount = x.TotalAmount,
                TotalWeight = x.TotalWeight,
                UserId = x.UserId,
                Id = x.Id,
                CreatedAt = x.CreatedAt,
                OrderItems = x.OrderItems,
                PocketItem = x.PocketItem,
            }).ToList();
        
        return new PaginatedList<Order>(orderResponses, totalCount, request.Page, request.PageSize);
    }
}