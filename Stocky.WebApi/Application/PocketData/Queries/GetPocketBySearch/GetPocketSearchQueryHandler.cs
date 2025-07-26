using MediatR;
using Microsoft.EntityFrameworkCore;
using Stocky.Shared.Models;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketData.Queries.GetPocketBySearch;

public class SearchPocketQuery : IRequest<List<Pocket>>
{
    public string? Text { get; set; }
}

public class GetPocketSearchQueryHandler(IPocketRepository pocketRepository, IPocketItemRepository pocketItemRepository)
    : IRequestHandler<SearchPocketQuery, List<Pocket>>
{
    public async Task<List<Pocket>> Handle(SearchPocketQuery pocketQuery, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(pocketQuery.Text))
        {
            return [];
        }
        
        if (pocketQuery.Text.Contains("@"))
        {
            var id = Convert.ToInt32(pocketQuery.Text.TrimStart('@'));

            var pocket = await pocketRepository.Queryable
                .Include(x => x.User)
                .Where(x => x.UserId == id)
                .ToListAsync(cancellationToken);
            return pocket;
        }

        pocketQuery.Text = pocketQuery.Text.ToLower();

        var pockets = await pocketRepository.Queryable
            .Include(x => x.User)
            .Where(x =>
                EF.Functions.Like(x.User.Name, $"%{pocketQuery.Text}%") ||
                EF.Functions.Like(x.TotalWeight.ToString(), $"%{pocketQuery.Text}%") ||
                EF.Functions.Like(x.TotalAmount.ToString(), $"%{pocketQuery.Text}%"))
            .ToListAsync(cancellationToken);

        if (pockets.Count == 0)
        {
            var pocketItem = await pocketItemRepository.Queryable
                .Include(pi => pi.Pocket)
                .ThenInclude(p => p.User)
                .FirstOrDefaultAsync(pi => pi.ProductBarCode == pocketQuery.Text, cancellationToken);

            if (pocketItem == null)
                return new List<Pocket>();

            var pocketId = pocketItem.PocketId;

            var pocketWithItems = await pocketRepository.Queryable
                .Include(p => p.User)
                .Include(p => p.PocketItems)
                .Where(p => p.Id == pocketId)
                .ToListAsync(cancellationToken);

            return pocketWithItems;
        }

        return pockets;
    }
}