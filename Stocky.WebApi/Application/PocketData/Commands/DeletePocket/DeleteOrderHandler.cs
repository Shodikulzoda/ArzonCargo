using MediatR;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Commands.DeletePocket;

public record DeletePocketCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class DeletePocketHandler(
    IPocketRepository pocketRepository,
    IProductRepository productRepository,
    IPocketItemRepository pocketItemRepository)
    : IRequestHandler<DeletePocketCommand, bool>
{
    public async Task<bool> Handle(DeletePocketCommand request, CancellationToken cancellationToken)
    {
        var pocketItem = pocketItemRepository.GetByPocketId(request.Id);

        if (pocketItem is not null)
        {
            foreach (var item in await pocketItem)
            {
                var product = await productRepository.GetById(item.ProductId);
                if (product != null)
                {
                    product.Status = Shared.Models.Enums.Status.Created;
                    await productRepository.Update(product);
                }
            }
        }

        var result = await pocketRepository.Delete(request.Id);

        return result;
    }
}