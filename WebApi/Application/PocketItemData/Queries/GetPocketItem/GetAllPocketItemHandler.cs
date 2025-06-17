using MediatR;
using WebApi.Application.Interfaces;
using WebApi.Domain.Models;

namespace WebApi.Application.PocketItemData.Queries.GetPocketItem;

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