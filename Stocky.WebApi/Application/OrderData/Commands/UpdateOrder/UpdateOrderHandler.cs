using MediatR;
using ReferenceClass.Models;
using ReferenceClass.Models.Enums;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderData.Commands.UpdateOrder;

public record UpdateOrderCommand : IRequest<Order>
{
    public int Id { get; set; }
    public double TotalWeight { get; set; }
    public double TotalAmount { get; set; }
    public int UserId { get; set; }
}

public class UpdateOrderHandler(IOrderRepository orderRepository)
    : IRequestHandler<UpdateOrderCommand, Order>
{
    public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetById(request.Id);
        if (order is null)
            return null;

        order.TotalWeight = request.TotalWeight;
        order.UserId = request.UserId;
        order.TotalAmount = request.TotalAmount;

        await orderRepository.Update(order);

        return order;
    }
}