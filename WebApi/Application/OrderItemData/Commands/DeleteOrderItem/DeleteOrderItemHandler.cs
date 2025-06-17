using MediatR;
using WebApi.Application.Interfaces;

namespace WebApi.Application.OrderItemData.Commands.DeleteOrderItem;

public record DeleteOrderItemCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteOrderItemHandler(IOrderItemRepository orderRepository)
    : IRequestHandler<DeleteOrderItemCommand, bool>
{
    public async Task<bool> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        return await orderRepository.Delete(request.Id);
    }
}