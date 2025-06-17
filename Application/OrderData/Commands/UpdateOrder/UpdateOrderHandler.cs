using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.OrderData.Commands.UpdateOrder;

public record UpdateOrderCommand : IRequest<OrderResponse>
{
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
}

public class UpdateOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<UpdateOrderCommand, OrderResponse?>
{
    public async Task<OrderResponse?> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            return null;
        }

        var order = mapper.Map<Order>(request);

        await orderRepository.Update(order);

        return mapper.Map<OrderResponse>(order);
    }
}