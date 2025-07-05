using MediatR;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Queries.GetAllPocket;

public record GetAllPocketQuery : IRequest<IEnumerable<Pocket>>
{
}

public class GetAllPocketHandler(IPocketRepository pocketRepository)
    : IRequestHandler<GetAllPocketQuery, IEnumerable<Pocket>>
{
    public async Task<IEnumerable<Pocket>> Handle(GetAllPocketQuery request, CancellationToken cancellationToken)
    {
        var pockets = await pocketRepository.GetAll();

        return pockets;
    }
}