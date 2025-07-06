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
            return [];
        }

        var pockets = await pocketRepository.Queryable
            .Where(x =>
                EF.Functions.Like(x.BarCode.ToString(), $"%{pocketQuery.Text}%") ||
                EF.Functions.Like(x.UserId.ToString(), $"%{pocketQuery.Text}%") ||
                EF.Functions.Like(x.Id.ToString(), $"%{pocketQuery.Text}%") ||
                EF.Functions.Like(x.TotalWeight.ToString(), $"%{pocketQuery.Text}%") ||
                EF.Functions.Like(x.TotalAmount.ToString(), $"%{pocketQuery.Text}%"))
            .ToListAsync(cancellationToken);

        return pockets;
    }
}