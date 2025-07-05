using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderItemData.Queries.GetAllOrderItem;

public record GetAllOrderItemQuery : IRequest<IEnumerable<OrderItem>>;

public class GetAllOrderItemHandler(IOrderItemRepository orderRepository)
    : IRequestHandler<GetAllOrderItemQuery, IEnumerable<OrderItem>>
{
    public async Task<IEnumerable<OrderItem>> Handle(GetAllOrderItemQuery request, CancellationToken cancellationToken)
    {
        return await orderRepository.GetAll();
    }
}