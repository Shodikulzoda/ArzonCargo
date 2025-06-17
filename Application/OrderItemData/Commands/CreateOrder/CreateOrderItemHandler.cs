using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.OrderItemData.Commands.CreateOrder;

public record CreateOrderItemCommand : IRequest<OrderItemResponse>
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}

public class CreateOrderItemHandler(IOrderItemRepository orderRepository, IMapper mapper)
    : IRequestHandler<CreateOrderItemCommand, OrderItemResponse?>
{
    public async Task<OrderItemResponse?> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0 || request.OrderId <= 0)
        {
            return null;
        }

        var order = mapper.Map<OrderItem>(request);

        await orderRepository.Add(order);

        return mapper.Map<OrderItemResponse>(order);
    }
}