using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Interfaces;

namespace WebApi.Application.PocketData.Queries.GetAllPocket;

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