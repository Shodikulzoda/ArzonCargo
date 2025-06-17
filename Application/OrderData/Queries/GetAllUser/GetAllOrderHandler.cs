using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.OrderData.Queries.GetAllUser;

public record GetAllOrderQuery : IRequest<IEnumerable<OrderResponse>>
{
}

public class GetAllOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetAllOrderQuery, IEnumerable<OrderResponse>>
{
    public async Task<IEnumerable<OrderResponse>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAll();

        var results = orders.Select(mapper.Map<OrderResponse>);

        return results;
    }
}