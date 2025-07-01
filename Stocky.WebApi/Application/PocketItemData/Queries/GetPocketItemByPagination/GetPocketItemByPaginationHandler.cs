using MediatR;
using ReferenceClass.Models;
using Stocky.WebApi.Application.Common;
using Stocky.WebApi.Application.Interfaces;

namespace Stocky.WebApi.Application.PocketItemData.Queries.GetPocketItemByPagination;

public record GetPocketItemByPaginationQuery(int Page, int PageSize) : IRequest<PaginatedList<PocketItem>>;

public class
    GetPocketItemByPaginationHandler(IPocketItemRepository pocketItemRepository)
    : IRequestHandler<GetPocketItemByPaginationQuery, PaginatedList<PocketItem>>
{
    public async Task<PaginatedList<PocketItem>> Handle(GetPocketItemByPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var pocketItemByPagination =
            await pocketItemRepository.GetPocketItemByPagination(request.Page, request.PageSize, cancellationToken);

        var pocketCount = await pocketItemRepository.Count();

        var pocketItems = pocketItemByPagination.Select(x => new PocketItem
        {
            Id = x.Id,
            ProductId = x.ProductId,
            Product = x.Product,
            PocketId = x.PocketId,
            Pocket = x.Pocket,
            CreatedAt = x.CreatedAt,
            IsDeleted = x.IsDeleted
        }).ToList();

        return new PaginatedList<PocketItem>(pocketItems, pocketCount, request.Page, request.PageSize);
    }
}