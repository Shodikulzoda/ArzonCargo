using MediatR;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderItemData.Commands.DeleteOrderItem;

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