using MediatR;
using Stocky.Shared.Models;
using Stocky.Shared.Models.Enums;
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

        var pocketById = await pocketRepository.GetById(request.PocketId);
        var productByBarCode = await productRepository.GetByBarCode(request.ProductBarCode);

        if (productByBarCode is not null && productByBarCode.Status == Status.Completed)
        {
            throw new Exception("This product is already completed");
        }

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

            productByBarCode.Status = Status.Completed;
            
            await pocketItemRepository.Add(pocketItem);
            
            productRepository.Update(productByBarCode);

            return pocketItem;
        }

        var product = new Product
        {
            BarCode = request.ProductBarCode
        };

        var getProductAfterAdding = await productRepository.Add(product);

        var newPocketItem = new PocketItem
        {
            ProductId = getProductAfterAdding.Id,
            Product = getProductAfterAdding,
            ProductBarCode = getProductAfterAdding.BarCode,
            PocketId = pocketById.Id,
            Pocket = pocketById
        };

        getProductAfterAdding.Status = Status.Completed;

        await pocketItemRepository.Add(newPocketItem);

        productRepository.Update(getProductAfterAdding);

        return newPocketItem;
    }
}