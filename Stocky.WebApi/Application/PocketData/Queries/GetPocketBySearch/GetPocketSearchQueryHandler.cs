using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Queries.GetPocketBySearch;

public class SearchPocketQuery : IRequest<List<Pocket>>
{
    public string? Text { get; set; }
}

public class GetPocketSearchQueryHandler(IPocketRepository pocketRepository)
    : IRequestHandler<SearchPocketQuery, List<Pocket>>
{
    public async Task<List<Pocket>> Handle(SearchPocketQuery pocketQuery, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(pocketQuery.Text))
        {
            return new List<Pocket>();
        }

        var search = pocketQuery.Text.ToLower();
        var pockets = await pocketRepository.Queryable
            .Where(x => x.BarCode.ToString().Contains(search) ||
                        x.Id.ToString().Contains(search) ||
                        x.UserId.ToString().Contains(search))
            .ToListAsync(cancellationToken);

        return pockets;
    }
}