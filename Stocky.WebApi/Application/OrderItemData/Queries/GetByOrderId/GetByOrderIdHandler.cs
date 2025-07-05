using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderItemData.Queries.GetByOrderId;

public record GetByOrderIdQuery : IRequest<PaginatedList<OrderItem>>
{
    public int OrderId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class GetOrdersByUserIdHandler(IOrderItemRepository orderItemRepository)
    : IRequestHandler<GetByOrderIdQuery, PaginatedList<OrderItem>>
{
    public async Task<PaginatedList<OrderItem>> Handle(GetByOrderIdQuery request, CancellationToken cancellationToken)
    {
        var ordersByUserId = await PaginatedList<OrderItem>.CreateAsync(
            orderItemRepository.Queryable.Where(x => x.OrderId == request.OrderId),
            request.Page,
            request.PageSize, cancellationToken);

        return new PaginatedList<OrderItem>(ordersByUserId.Items, ordersByUserId.TotalCount, ordersByUserId.PageNumber,
            ordersByUserId.TotalPages);
    }
}