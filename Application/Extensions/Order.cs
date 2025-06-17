using Application.Dtos.Response;
using Application.OrderData.Commands.CreateOrder;

namespace Application.Extensions;

public static class Order
{
    public static OrderResponse ToOrder(this CreateOrderCommand command)
    {
        return new OrderResponse()
        {
            BarCode = command.BarCode,
            TotalWeight = command.TotalWeight,
            UserId = command.UserId,
        };
    }
}