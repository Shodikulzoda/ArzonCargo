using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.OrderData.Queries.GetUserById;

public record GetOrderByIdQuery : IRequest<OrderResponse>
{
    public int Id { get; set; }
}

public class GetOrderByIdHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<GetOrderByIdQuery, OrderResponse?>
{
    public async Task<OrderResponse?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            return null;
        }

        var order = orderRepository.GetById(request.Id);

        return mapper.Map<OrderResponse>(order);
    }
}