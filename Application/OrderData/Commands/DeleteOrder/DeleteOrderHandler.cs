using Application.Dtos.Response;
using Application.Interfaces;
using MediatR;

namespace Application.OrderData.Commands.DeleteOrder;

public record DeleteOrderCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeleteOrderHandler(IOrderRepository orderRepository)
    : IRequestHandler<DeleteOrderCommand, OrderResponse?>
{
    public async Task<OrderResponse?> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.Delete(request.Id);

        return 
    }
}