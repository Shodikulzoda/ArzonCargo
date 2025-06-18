using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Application.ProductData.Queries.GetProductById;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderItemData.Commands.CreateOrderItem;

public record CreateOrderItemCommand : IRequest<OrderItem?>
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}

public class CreateOrderItemHandler(IOrderItemRepository orderRepository, IProductRepository productRepository)
    : IRequestHandler<CreateOrderItemCommand, OrderItem?>
{
    public async Task<OrderItem?> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.ProductId);
        if (product is null)
        {
            return null;
        }

        var order = new OrderItem
        {
            ProductId = request.ProductId,
            OrderId = request.OrderId
        };

        await orderRepository.Add(order);

        return order;
    }
}