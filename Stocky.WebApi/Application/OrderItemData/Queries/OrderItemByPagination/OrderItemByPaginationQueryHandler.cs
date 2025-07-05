using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderItemData.Queries.OrderItemByPagination;

public record OrderItemByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<OrderItem>>;

public class OrdersByPaginationQueryHandler(IOrderItemRepository orderItemRepository)
    : IRequestHandler<OrderItemByPaginationQuery, PaginatedList<OrderItem>>
{
    public async Task<PaginatedList<OrderItem>> Handle(OrderItemByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var orderItem = await orderItemRepository
            .GetOrderItemByPagination(request.Page, request.PageSize, cancellationToken);

        var orderCount = await orderItemRepository.Count();

        var orderResponse = orderItem.Select(x => new OrderItem
        {
            OrderId = x.OrderId,
            ProductId = x.ProductId,
            CreatedAt = x.CreatedAt
        }).ToList();

        return new PaginatedList<OrderItem>(orderResponse, orderCount, request.Page, request.PageSize);
    }
}