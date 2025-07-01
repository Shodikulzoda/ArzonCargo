using MediatR;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderData.Queries.GetOrderById;

public record GetOrderByIdQuery : IRequest<Order>
{
    public int Id { get; set; }
}

public class GetOrderByIdHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrderByIdQuery, Order>
{
    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var result= await orderRepository.GetById(request.Id);
        if (result is null)
        {
            throw new Exception("Order not found");
        }
        return result;
    }
}