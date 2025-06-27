using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Common;
using WebApi.Application.Interfaces;

namespace WebApi.Application.OrderData.Queries.GetOrdersByUserId;

public record GetOrdersByUserIdQuery : IRequest<PaginatedList<Order>>
{
    public int UserId { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}

public class GetOrdersByUserIdHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrdersByUserIdQuery, PaginatedList<Order>>
{
    public async Task<PaginatedList<Order>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
    {
        var ordersByUserId = await PaginatedList<Order>.CreateAsync(
            orderRepository.Queryable.Where(x => x.UserId == request.UserId),
            request.Page,
            request.PageSize, cancellationToken);

        return new PaginatedList<Order>(ordersByUserId.Items, ordersByUserId.TotalCount, ordersByUserId.PageNumber,
            ordersByUserId.TotalPages);
    }
}