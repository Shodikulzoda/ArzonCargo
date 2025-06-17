using Application.Dtos.Response;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.OrderData.Commands.DeleteOrder;

public record DeleteOrderCommand : IRequest<OrderResponse>
{
    public int Id { get; set; }
}

public class DeleteOrderHandler(IOrderRepository orderRepository, IMapper mapper)
    : IRequestHandler<DeleteOrderCommand, OrderResponse?>
{
    public async Task<OrderResponse?> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetById(request.Id);
        if (order is null)
        {
            return null;
        }

        await orderRepository.Delete(order);

        return mapper.Map<OrderResponse>(order);
    }
}