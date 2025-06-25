using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.PocketItemData.Commands.CreatePocketItem;

public record CreatePocketItemCommand : IRequest<PocketItem>
{
    public int ProductId { get; set; }
    public int PocketId { get; set; }
}

public class CreatePocketItemHandler(
    IPocketItemRepository pocketItemRepository,
    IProductRepository productRepository,
    IPocketRepository pocketRepository)
    : IRequestHandler<CreatePocketItemCommand, PocketItem?>
{
    public async Task<PocketItem?> Handle(CreatePocketItemCommand request, CancellationToken cancellationToken)
    {
        if (request.ProductId <= 0 || request.PocketId <= 0)
        {
            throw new Exception();
        }

        var productById = await productRepository.GetById(request.ProductId);
        var pocketById = await pocketRepository.GetById(request.PocketId);

        if (productById is null || pocketById is null)
        {
            return null;
        }

        var pocketItem = new PocketItem
        {
            ProductId = productById.Id,
            Product = productById,
            PocketId = pocketById.Id,
            Pocket = pocketById
        };

        await pocketItemRepository.Add(pocketItem);

        return pocketItem;
    }
}