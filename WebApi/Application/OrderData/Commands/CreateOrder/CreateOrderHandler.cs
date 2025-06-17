using MediatR;
using WebApi.Application.Dtos.Response;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderData.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<OrderResponse>
{
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
}

public class CreateOrderHandler(IOrderRepository orderRepository)
    : IRequestHandler<CreateOrderCommand, OrderResponse?>
{
    public async Task<OrderResponse?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            return null;
        }

        var order = new Order()
        {
            BarCode = request.BarCode,
            TotalWeight = request.TotalWeight,
            UserId = request.UserId
        };

        var add = await orderRepository.Add(order);

        return new OrderResponse()
        {
            Id = add.Id,
            BarCode = add.BarCode,
            TotalWeight = add.TotalWeight,
            UserId = add.UserId,
            CreatedAt = add.CreatedAt,
            Status = add.Status,
            TotalAmount = add.TotalAmount,
        };
    }
}