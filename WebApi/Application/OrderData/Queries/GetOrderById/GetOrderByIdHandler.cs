using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderData.Queries.GetOrderById;

public record GetOrderByIdQuery : IRequest<Order>
{
    public int Id { get; set; }
}

public class GetOrderByIdHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrderByIdQuery, Order>
{
    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id==0)
        {
            return null;
        }
        
        return  await orderRepository.GetById(request.Id);
    }
}