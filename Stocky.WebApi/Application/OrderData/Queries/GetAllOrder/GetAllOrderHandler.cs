using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderData.Queries.GetAllOrder;

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