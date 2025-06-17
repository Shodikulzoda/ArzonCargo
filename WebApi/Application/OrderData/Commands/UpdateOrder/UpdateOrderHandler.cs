using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderData.Commands.UpdateOrder;

public record UpdateOrderCommand : IRequest<Order>
{
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
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
        
        var order=orderRepository.Querable.FirstOrDefault(x=>x.BarCode==request.BarCode);

        if (order == null)
        {
            return null;
        }

        await orderRepository.Update(order);

        return order;
    }
}