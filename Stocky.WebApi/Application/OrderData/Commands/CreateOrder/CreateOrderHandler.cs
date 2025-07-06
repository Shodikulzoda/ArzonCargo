using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderData.Commands.CreateOrder;

public record CreateOrderCommand : IRequest<Order>
{
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

        var pocketById = await pocketRepository.GetByUserId(request.UserId);
        if (pocketById is null)
        {
            return null;
        }

        var orderItems = pocketById.PocketItems.Select(x => new OrderItem
        {
            ProductId = x.ProductId,
            Product = x.Product,
            CreatedAt = x.CreatedAt,
            IsDeleted = x.IsDeleted
        }).ToList();

        var order = new Order()
        {
            BarCode = pocketById.BarCode,
            TotalWeight = pocketById.TotalWeight,
            TotalAmount = pocketById.TotalAmount,
            UserId = pocketById.UserId,
            OrderItems = orderItems,
            CreatedAt = DateTime.UtcNow
        };
        var add = await orderRepository.Add(order);

        orderItems.Select(orderItemRepository.Add);

        var pocketItemsByPocketId = await pocketItemRepository.GetByPocketId(pocketById.Id);
        foreach (var pocketItem in pocketItemsByPocketId)
        {
            if (pocketItem is not null)
            {
                await pocketItemRepository.Delete(pocketItem.Id);
            }
        }

        await pocketRepository.Delete(pocketById.Id);

        return add;
    }
}