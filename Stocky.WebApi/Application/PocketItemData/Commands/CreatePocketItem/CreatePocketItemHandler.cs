using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketItemData.Commands.CreatePocketItem;

public record CreatePocketItemCommand : IRequest<PocketItem>
{
    public string? ProductBarCode { get; set; }
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
        if (request.PocketId <= 0)
        {
            throw new Exception();
        }

        var productById = await productRepository.GetById(request.ProductId);
        var pocketById = await pocketRepository.GetById(request.PocketId);
        var productByBarCode = await productRepository.GetByBarCode(request.ProductBarCode);

        if (productByBarCode is not null)
        {
            var pocketItem = new PocketItem
            {
                ProductId = productByBarCode.Id,
                Product = productByBarCode,
                ProductBarCode = productByBarCode.BarCode,
                PocketId = pocketById.Id,
                Pocket = pocketById
            };

            await pocketItemRepository.Add(pocketItem);

            return pocketItem;
        }

        var product = new Product
        {
            BarCode = request.ProductBarCode
        };

        await productRepository.Add(product);

        var productByBarCode1 = await productRepository.GetByBarCode(request.ProductBarCode);

        var pocketItem1 = new PocketItem
        {
            ProductId = productByBarCode1.Id,
            Product = productByBarCode1,
            ProductBarCode = productByBarCode1.BarCode,
            PocketId = pocketById.Id,
            Pocket = pocketById
        };

        await pocketItemRepository.Add(pocketItem1);
        
        return pocketItem1;
    }
}