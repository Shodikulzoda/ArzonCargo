using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderItemData.Queries.GetAllOrderItem;

public record GetAllOrderItemQuery : IRequest<IEnumerable<OrderItem>>;

public class GetAllOrderItemHandler(IOrderItemRepository orderRepository)
    : IRequestHandler<GetAllOrderItemQuery, IEnumerable<OrderItem>>
{
    public async Task<IEnumerable<OrderItem>> Handle(GetAllOrderItemQuery request, CancellationToken cancellationToken)
    {
        return await orderRepository.GetAll();
    }
}