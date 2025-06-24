using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.PocketItemData.Commands.CreatePocketItem;

public record CreatePocketItemCommand : IRequest<PocketItem>
{ 
    public int ProductId { get; set; }
    public int PocketId { get; set; }
}

public class CreatePocketItemHandler(IPocketItemRepository pocketItemRepository)  
    : IRequestHandler<CreatePocketItemCommand,PocketItem>
{
    public async Task<PocketItem> Handle(CreatePocketItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0|| request.PocketId <= 0)
        {
            throw new Exception();
        }

        var pocketItem = new PocketItem
        {
            ProductId = request.ProductId,
            PocketId = request.PocketId
        };

        await pocketItemRepository.Add(pocketItem);

        return pocketItem;
    }
}