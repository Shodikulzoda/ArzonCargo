using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderItemData.Commands.CreateOrder;

public record CreateOrderItemCommand : IRequest<OrderItem>
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    
}

public class CreateOrderItemHandler(IOrderItemRepository orderRepository)
    : IRequestHandler<CreateOrderItemCommand, OrderItem>
{
    public async Task<OrderItem?> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0 || request.OrderId <= 0)
        {
            return null;
        }

        var order = new OrderItem()
        {
            ProductId = request.ProductId,
            OrderId = request.OrderId
        };
        
        await orderRepository.Add(order);

        return order;
    }
}