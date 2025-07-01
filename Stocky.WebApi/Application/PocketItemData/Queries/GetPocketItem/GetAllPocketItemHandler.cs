using MediatR;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketItemData.Queries.GetPocketItem;

public record GetAllPocketItemQuery : IRequest<IEnumerable<PocketItem>>;

public class GetAllPocketItemHandler(IPocketItemRepository pocketItemRepository)
    : IRequestHandler<GetAllPocketItemQuery, IEnumerable<PocketItem>>
{
    public async Task<IEnumerable<PocketItem>> Handle(GetAllPocketItemQuery request,
        CancellationToken cancellationToken)
    {
        return await pocketItemRepository.GetAll();
    }
}