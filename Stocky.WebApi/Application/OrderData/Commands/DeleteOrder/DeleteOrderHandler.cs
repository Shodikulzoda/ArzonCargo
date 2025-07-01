using MediatR;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.OrderData.Commands.DeleteOrder;

public record DeleteOrderCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteOrderHandler(IOrderRepository orderRepository)
    : IRequestHandler<DeleteOrderCommand, bool>
{
    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var result = await orderRepository.Delete(request.Id);

        return result;
    }
}