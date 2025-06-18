using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Application.ProductData.Queries.GetProductById;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderData.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<Order>
{
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
}

public class CreateOrderHandler(IOrderRepository orderRepository, IUserRepository userRepository)
    : IRequestHandler<CreateOrderCommand, Order>
{
    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = userRepository.GetById(request.UserId);
        if (user.Result is null)
             throw new Exception("User not found");

        if (string.IsNullOrEmpty(request.BarCode))
        {
            return null;
        }

        var order = new Order()
        {
            BarCode = request.BarCode,
            TotalWeight = request.TotalWeight,
            UserId = request.UserId,
            CreatedAt = DateTime.Now
        };

        var add = await orderRepository.Add(order);

        return add;
    }
}