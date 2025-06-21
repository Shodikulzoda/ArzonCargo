using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.OrderItemData.Queries.GetOrderItemById;

public record GetOrderItemByIdQuery : IRequest<OrderItem>
{
    public int Id { get; set; }
}

public class GetOrderItemByIdHandler(IOrderItemRepository orderItemRepository)
    : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
{
    public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
       return await orderItemRepository.GetById(request.Id) ?? throw new Exception("OrderItem not found");
    }
}