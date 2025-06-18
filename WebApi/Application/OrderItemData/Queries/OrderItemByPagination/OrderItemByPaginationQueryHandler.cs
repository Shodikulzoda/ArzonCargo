using MediatR;
using WebApi.Application.Common;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderItemData.Queries.OrderItemByPagination;

public record OrderItemByPaginationQuery(int PageNumber, int PageSize) : IRequest<PaginatedList<OrderItem>>;

public class OrdersByPaginationQueryHandler(IOrderItemRepository orderItemRepository)
    : IRequestHandler<OrderItemByPaginationQuery, PaginatedList<OrderItem>>
{
    public async Task<PaginatedList<OrderItem>> Handle(OrderItemByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var orderItem = await orderItemRepository
            .GetOrderItemByPagination(request.PageNumber, request.PageSize, cancellationToken);

        var totalCount = await orderItemRepository.Count();

        var orderResponse = orderItem.Select(x => new OrderItem
        {
            OrderId = x.OrderId,
            ProductId = x.ProductId,
            CreatedAt = x.CreatedAt
        }).ToList();

        return new PaginatedList<OrderItem>(orderResponse, count: totalCount, pageNumber: request.PageNumber,
            pageSize: request.PageSize);
    }
}