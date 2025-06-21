using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.PocketItemData.Commands.UpdatePocketItem;

public record UpdatePocketItemCommand : IRequest<PocketItem>
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}

public class UpdatePocketItemHandler(IPocketItemRepository pocketItemRepository)
    : IRequestHandler<UpdatePocketItemCommand, PocketItem>
{
    public async Task<PocketItem> Handle(UpdatePocketItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0 || request.OrderId <= 0)
        {
            throw new Exception();
        }

        var pocketItem = new PocketItem()
        {
            ProductId = request.ProductId,
            OrderId = request.OrderId
        };
        
        return pocketItem;
    }
}