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

public class CreateOrderItemHandler : IRequestHandler<CreateOrderItemCommand, OrderItem?>
{
    private readonly IOrderItemRepository _orderRepository;
    private readonly IMediator _mediator;

    public CreateOrderItemHandler(IOrderItemRepository orderRepository, IMediator mediator)
    {
        _orderRepository = orderRepository;
        _mediator = mediator;
    }

    public async Task<OrderItem?> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new GetProductByIdQuery { Id = request.ProductId }, cancellationToken);

        var order = new OrderItem()
        {
            ProductId = request.ProductId,
            OrderId = request.OrderId
        };

        await _orderRepository.Add(order);

        return order;
    }
}