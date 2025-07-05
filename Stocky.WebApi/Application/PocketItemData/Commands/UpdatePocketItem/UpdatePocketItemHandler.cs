using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketItemData.Commands.UpdatePocketItem;

public record UpdatePocketItemCommand : IRequest<PocketItem>
{
    public int ProductId { get; set; }
    public int PocketId { get; set; }
}

public class UpdatePocketItemHandler(IPocketItemRepository pocketItemRepository)
    : IRequestHandler<UpdatePocketItemCommand, PocketItem>
{
    public async Task<PocketItem> Handle(UpdatePocketItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0 || request.PocketId <= 0)
        {
            throw new Exception();
        }

        var pocketItem = new PocketItem()
        {
            ProductId = request.ProductId,
            PocketId = request.PocketId
        };

        await pocketItemRepository.Update(pocketItem);

        return pocketItem;
    }
}