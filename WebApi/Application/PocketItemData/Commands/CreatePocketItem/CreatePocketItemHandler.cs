using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.PocketItemData.Commands.CreatePocketItem;

public record CreatePocketItemCommand : IRequest<PocketItem>
{ 
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}

public class CreatePocketItemHandler(IPocketItemRepository pocketItemRepository)  
    : IRequestHandler<CreatePocketItemCommand,PocketItem>
{
    public async Task<PocketItem> Handle(CreatePocketItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0|| request.OrderId <= 0)
        {
            throw new Exception();
        }

        var pocketItem = new PocketItem
        {
            ProductId = request.ProductId,
            OrderId = request.OrderId
        };

        await pocketItemRepository.Add(pocketItem);

        return pocketItem;
    }
}