using MediatR;
using ReferenceClass.Models;
using ReferenceClass.Models.Enums;
using WebApi.Application.Interfaces;

namespace WebApi.Application.OrderData.Commands.UpdateOrder;

public record UpdateOrderCommand : IRequest<Order>
{
    public int Id { get; set; }
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
    public double TotalAmount { get; set; }
    public Status Status { get; set; }
    public int UserId { get; set; }
}

public class UpdateOrderHandler(IOrderRepository orderRepository)
    : IRequestHandler<UpdateOrderCommand, Order>
{
    public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BarCode))
        {
            return null;
        }

        var order = await orderRepository.GetById(request.Id);
        if (order is null)
            return null;
        
        order.TotalWeight = request.TotalWeight;
        order.UserId = request.UserId;
        order.BarCode = request.BarCode;

        await orderRepository.Update(order);

        return order;
    }
}