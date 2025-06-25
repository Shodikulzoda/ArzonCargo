using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.OrderData.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<Order>
{
    public string? BarCode { get; set; }
    public double TotalWeight { get; set; }
    public int UserId { get; set; }
}

public class CreateOrderHandler(
    IOrderRepository orderRepository,
    IUserRepository userRepository,
    IOrderItemRepository orderItemRepository,
    IPocketItemRepository pocketItemRepository,
    IPocketRepository pocketRepository)
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

        var byUserId = await pocketRepository.GetByUserId(request.UserId);
        if (byUserId is null)
        {
            return null;
        }

        var orderItems = byUserId.PocketItems.Select(x => new OrderItem
        {
            ProductId = x.ProductId,
            Product = x.Product,
            CreatedAt = x.CreatedAt,
            IsDeleted = x.IsDeleted
        }).ToList();

        var order = new Order()
        {
            BarCode = request.BarCode,
            TotalWeight = request.TotalWeight,
            UserId = request.UserId,
            OrderItems = orderItems,
            CreatedAt = DateTime.UtcNow
        };
        var add = await orderRepository.Add(order);

        orderItems.Select(orderItemRepository.Add);

        var byPocketId = await pocketItemRepository.GetByPocketId(byUserId.Id);

        byPocketId.Select(x => pocketItemRepository.Delete(x.Id));

        pocketRepository.Delete(byUserId.Id);

        return add;
    }
}