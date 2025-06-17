using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.OrderData.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<OrderResponse>
{
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
}

public class CreateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<CreateOrderCommand, OrderResponse?>
{
    public async Task<OrderResponse?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            return null;
        }

        var order = mapper.Map<Order>(request);

        await orderRepository.Add(order);

        return mapper.Map<OrderResponse>(order);
    }
}