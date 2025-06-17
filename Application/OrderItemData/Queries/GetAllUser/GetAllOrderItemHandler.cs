using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.OrderItemData.Queries.GetAllUser;

public record GetAllOrderItemQuery : IRequest<IEnumerable<OrderItemResponse>>
{
}

public class GetAllOrderItemHandler(IOrderItemRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetAllOrderItemQuery, IEnumerable<OrderItemResponse>>
{
    public async Task<IEnumerable<OrderItemResponse>> Handle(GetAllOrderItemQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAll();

        var results = orders.Select(mapper.Map<OrderItemResponse>);

        return results;
    }
}