using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.OrderData.Queries.GetAllUser;

public record GetAllOrderQuery : IRequest<IEnumerable<Order>>
{
}

public class GetAllOrderHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetAllOrderQuery, IEnumerable<Order>>
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAll();
        
        return orders;
    }
}