using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.OrderItemData.Commands.DeleteOrder;

public record DeleteOrderItemCommand : IRequest<OrderItemResponse>
{
    public int Id { get; set; }
}

public class DeleteOrderItemHandler(IOrderItemRepository orderRepository, IMapper mapper)
    : IRequestHandler<DeleteOrderItemCommand, OrderItemResponse?>
{
    public async Task<OrderItemResponse?> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetById(request.Id);
        if (order is null)
        {
            return null;
        }

        await orderRepository.Delete(order);

        return mapper.Map<OrderItemResponse>(order);
    }
}