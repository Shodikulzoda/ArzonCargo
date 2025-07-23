using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderItemData.Commands.UpdateOrderItem;

public record UpdateOrderItemCommand : IRequest<OrderItem>
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}

public class UpdateOrderItemHandler(IOrderItemRepository orderRepository)
    : IRequestHandler<UpdateOrderItemCommand, OrderItem?>
{
    public async Task<OrderItem?> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0 || request.OrderId <= 0)
        {
            return null;
        }

        var orderItem = orderRepository.Queryable
            .FirstOrDefault(x => x.ProductId == request.ProductId && x.OrderId == request.OrderId);

        await orderRepository.Update(orderItem);

        return orderItem;
    }
}