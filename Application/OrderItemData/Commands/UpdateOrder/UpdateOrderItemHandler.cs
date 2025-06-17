using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.OrderItemData.Commands.UpdateOrder;

public record UpdateOrderItemCommand : IRequest<OrderItemResponse>
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}

public class UpdateOrderItemHandler(IOrderItemRepository orderRepository, IMapper mapper)
    : IRequestHandler<UpdateOrderItemCommand, OrderItemResponse?>
{
    public async Task<OrderItemResponse?> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0 || request.OrderId <= 0)
        {
            return null;
        }

        var order = mapper.Map<OrderItem>(request);

        await orderRepository.Update(order);

        return mapper.Map<OrderItemResponse>(order);
    }
}