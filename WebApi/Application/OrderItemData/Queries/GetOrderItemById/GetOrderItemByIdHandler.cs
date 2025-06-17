using MediatR;
using WebApi.Application.Interfaces;

namespace WebApi.Application.OrderItemData.Queries.GetOrderItemById;

public record GetOrderItemByIdQuery : IRequest<bool>
{
    public int Id { get; }
}

public class GetOrderItemByIdHandler(IOrderItemRepository orderRepository)
    : IRequestHandler<GetOrderItemByIdQuery, bool>
{
    public async Task<bool> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
       return await orderRepository.Delete(request.Id);
    }
}