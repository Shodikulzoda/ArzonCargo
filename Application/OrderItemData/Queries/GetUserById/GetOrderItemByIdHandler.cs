using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.OrderItemData.Queries.GetUserById;

public record GetOrderItemByIdQuery : IRequest<OrderItemResponse>
{
    public int Id { get; }
}

public class GetOrderItemByIdHandler(IOrderItemRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetOrderItemByIdQuery, OrderItemResponse?>
{
    public async Task<OrderItemResponse?> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            return null;
        }

        var order = await orderRepository.GetById(request.Id);

        return mapper.Map<OrderItemResponse>(order);
    }
}