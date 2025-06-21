using MediatR;
using ReferenceClass.Models;
using WebApi.Application.Common;
using WebApi.Application.Interfaces;

namespace WebApi.Application.PocketItemData.Queries.GetPocketItemByPagination;

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
            OrderId = x.OrderId,
            Order = x.Order,
            CreatedAt = x.CreatedAt,
            IsDeleted = x.IsDeleted
        }).ToList();

        return new PaginatedList<PocketItem>(pocketItems, pocketCount, request.Page, request.PageSize);
    }
}